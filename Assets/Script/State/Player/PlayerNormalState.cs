using UnityEngine;
using HellGame.Model;

namespace HellGame.State
{
    public class PlayerNormalState : PlayerState
    {
        public override PlayerStateType Type => PlayerStateType.Normal;

        public override void Update()
        {
            // TODO: バ美肉可能か判定する
        }

        public override void OnEnter()
        {
            Debug.Log("プレイヤー：通常状態　へ変更します");;
        }

        public override void OnExit()
        {
            Debug.Log("プレイヤー：通常状態 から抜けます");;
        }

        public override void OnMove(int x, int y)
        {
            Debug.Log($"プレイヤー：通常状態　位置が変更されました：（{x}, {y}）");
            Target.Position = (x, y);
        }

        public override void OnCollide(object target)
        {
            Debug.Log($"プレイヤー：通常状態　物体と衝突しました");
        }
    }
}
