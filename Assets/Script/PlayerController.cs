using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HellGame.Model;

namespace HellGame
{
    public class PlayerController : MonoBehaviour, IPlayerModelDelegate
    {
        public PlayerModel Player = null;

        void Start()
        {
            //
        }

        void OnDestroy()
        {
            // PlayerController自体はUnityのライフサイクルに依存するため，
            // Destroy後はすぐに無効化されてしまうため注意．
            Player.Delegate = null;
            Player = null;
        }

        void Update()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

        }

        public void PlayerModelUpdateCoins(PlayerModel sender, int coins)
        {
            // コインの状態変更
        }

        public void PlayerModelUpdateBoost(PlayerModel sender, int boost)
        {
            // ブースト状態の変更
        }

        public void PlayerModelUpdatePosition(PlayerModel sender, (int, int) position)
        {
            // 位置の変更
        }
    }
}
