using UnityEngine;
using HellGame.Model;
using System;

namespace HellGame
{
    public delegate void GameStartDelegate();
    public delegate void GameEndDelegate();

    public class GameController : MonoBehaviour
    {
        // 自分のインスタンスはここに持っておく
        static GameController _controller;

        /// <summary>
        /// ゲームコントローラのインスタンスを取得する．
        /// </summary>
        public static GameController Instance
        {
            get
            {
                if (_controller == null)
                {
                    var i = FindObjectOfType<GameController>();
                    if (i != null)
                    {
                        _controller = i;
                        return i;
                    }

                    var obj = new GameObject("Game Controller");
                    _controller = obj.AddComponent<GameController>();
                    DontDestroyOnLoad(obj);
                }

                return _controller;
            }
        }

        [Obsolete("初期化はBootstrap等に任せて，RunOnceAfterInitにゲーム開始後の処理を書いてね")]
        public static GameController EnsureGame
        {
            get
            {
                var self = GameController.Instance;
                
                if (self.m_model == null)
                {
                    self.InitGame();
                }

                return self;
            }
        }

        // 時間
        float m_timeBegin = 0.0f;
        public float Now => Time.time - m_timeBegin;

        // ゲームの実体はコレ
        private GameModel m_model = null;

        public GameModel Model => m_model;

        public bool Active => m_model != null;

        public GameStartDelegate StartEvent = delegate {};
        public GameEndDelegate EndEvent = delegate {};

        // とりあえずタイムリミット
        public readonly float timeLimit = 120.0f;

        // ええいもうメンドウくせえ！
        public int SuperChatTotal = 0;
        public int WishlistTotal = 0;

        private void Awake()
        {
            if (_controller == null)
            {
                _controller = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        /// <summary>
        /// ゲームの初期化を行う
        /// </summary>
        /// 

        private void Start()
        {
            // InitGame();
        }

        public void InitGame()
        {
            if (m_model != null)
            {
                Debug.LogWarning("ゲームコントローラ：　＜警告＞既にゲームが開始されています．");
                return;
            }

            m_model = new GameModel();
            m_timeBegin = Time.time;

            StartEvent();

            Debug.Log("ゲームコントローラ：　ゲームが開始されました");
        }

        /// <summary>
        /// ゲームの終了処理を行う
        /// </summary>
        public void EndGame()
        {
            EndEvent();

            // やる気を感じない
            SuperChatTotal = Model.Bias.MoneyFromSuperchat;
            WishlistTotal = Model.Bias.MoneyFromWishlist;
            
            m_model = null;
            Debug.Log("ゲームコントローラ：　ゲームを終了します");
        }

        public void RunOnceAfterInit(Action action)
        {
            if (Active)
            {
                action();
            }

            void action_()
            {
                action();
                StartEvent -= action_;
            }

            StartEvent += action_;
        }

        public void Cleanup(Action action)
        {
            if (Active)
            {
                action();
            }

            void action_()
            {
                action();
                EndEvent -= action_;
            }

            EndEvent += action_;
        }

        void Update()
        {
            if (!Active)
            {
                return;
            }
            
            m_model.Update();

            if (Now >= timeLimit)
            {
                EndGame();
            }
        }
    }
}
