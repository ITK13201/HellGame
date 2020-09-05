using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HellGame.Model;

namespace HellGame
{
    public class PlayerController : MonoBehaviour, IPlayerModelDelegate
    {
        public PlayerModel Player = null;

        private Rigidbody2D rb = null;
        private SpriteRenderer sr = null;
        public GameObject grid = null;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            rotate = grid.transform.rotation.eulerAngles.z;

        }

        void OnDestroy()
        {
            // PlayerController自体はUnityのライフサイクルに依存するため，
            // Destroy後はすぐに無効化されてしまうため注意．
            Player.Delegate = null;
            Player = null;
        }


        bool babiniku = true;//バ美肉状態かどうかのフラグ


        private float rotate;

        bool right = false;

        // Update is called once per frame
        void Update()
        {
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");

            float vx;
            float vy;


            float speed = 17.0f;

            vy = y * Mathf.Cos(rotate * 3.1415f / 180.0f) + x * Mathf.Sin(rotate * 3.1415f / 180.0f);
            vx = -y * Mathf.Sin(rotate * 3.1415f / 180.0f) + x * Mathf.Cos(rotate * 3.1415f / 180.0f);

            rb.velocity = new Vector2(vx * speed, vy * speed);



            if (right && vx < -0.1f)
            {
                sr.flipX = false;
                right = false;
            }
            if (!right && vx > 0.1f)
            {
                sr.flipX = true;
                right = true;
            }

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
