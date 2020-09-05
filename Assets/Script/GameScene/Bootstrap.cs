using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HellGame;

namespace HellGame.GameScene
{
    public class Bootstrap : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // ゲームを初期化
            var c = GameController.Instance;
            c.InitGame();
        }
    }
}
