using UnityEngine;
using HellGame.Model;

namespace HellGame.State
{
    public class PlayerNormalState : PlayerState
    {
        public override PlayerStateType Type => PlayerStateType.Normal;

        public override void Update()
        {
            // 何もしない
        }

        public override void OnEnter()
        {
            Debug.Log("プレイヤー：通常状態　へ変更します");;
        }

        public override void OnExit()
        {
            Debug.Log("プレイヤー：通常状態 から抜けます");;
        }

        public override void OnBabinikuTriggered()
        {
            Debug.Log("プレイヤー：通常状態 バ美肉をトリガー");
            StateMachine.NotifyNextState<PlayerBabinikuState>();
        }
    }
}
