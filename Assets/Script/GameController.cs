﻿using UnityEngine;
using HellGame.Model;

namespace HellGame
{
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

        // 時間
        float m_timeBegin = 0.0f;
        public float Now => Time.time - m_timeBegin;

        // ゲームの実体はコレ
        private GameModel m_model = null;

        public bool Active => m_model != null;


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
            InitGame();

        }

        public void InitGame()


        {
            if (m_model != null)
            {
                Debug.LogWarning("fatal: game model already initialized");
                return;
            }

            m_model = new GameModel();
            m_timeBegin = Time.time;
        }

        /// <summary>
        /// ゲームの終了処理を行う
        /// </summary>
        public void EndGame()
        {
            m_model = null;
        }

        void Update()
        {
            m_model.Update();
        }
    }
}
