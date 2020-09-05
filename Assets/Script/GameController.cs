using UnityEngine;
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
        
        // ゲームの実体はコレ
        private GameModel m_model = null;

        /// <summary>
        /// ゲームの初期化を行う
        /// </summary>
        public void InitGame()
        {
            if (m_model != null) {
                Debug.LogWarning("");
                return;
            }
        }

        /// <summary>
        /// ゲームの終了処理を行う
        /// </summary>
        public void EndGame()
        {
            m_model = null;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
