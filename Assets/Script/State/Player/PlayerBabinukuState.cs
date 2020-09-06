using UnityEngine;
using HellGame.Model;

namespace HellGame.State
{
    public class PlayerBabinikuState : PlayerState
    {
        public override PlayerStateType Type => PlayerStateType.Babiniku;

        public override bool IsBabiniku => true;

        public override void Update()
        {
            // TODO: バ美肉状態を維持できるかを判定
        }

        public override void OnEnter()
        {
            Debug.Log("プレイヤー：バ美肉状態　へ変更します");;
        }

        public override void OnExit()
        {
            Debug.Log("プレイヤー：バ美肉状態 から抜けます");;
        }


        public override void OnCollide(object target)
        {
            Debug.Log("プレイヤー：バ美肉状態　物体と衝突しました");

            // お金を追加
            Target.Coins += 10000;
        }

        public override void OnBabinikuTriggered()
        {
            Debug.Log("プレイヤー：バ美肉状態 バ美肉をトリガー（無視）");
        }
    }
}
