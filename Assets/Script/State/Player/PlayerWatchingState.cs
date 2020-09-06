using System;
using UnityEngine;
using HellGame.Model;

namespace HellGame.State
{
    public class PlayerWatchingState : PlayerState
    {
        public override PlayerStateType Type => PlayerStateType.Watching;
        private PlayerState _previousState = null;

        public override bool IsBabiniku => _previousState.IsBabiniku;

        public PlayerWatchingState(PlayerState previous)
        {
            _previousState = previous;
        }

        public override void Update()
        {

        }

        public void BackToPreviousState()
        {
            if (_previousState == null)
            {
                throw new NullReferenceException("the previous state is null, which is unexpected");
            }

            StateMachine.NotifyNextState(_previousState);
        }

        public override void OnEnter()
        {
            Debug.Log("プレイヤー：配信視聴　へ変更します");
        }

        public override void OnExit()
        {
            Debug.Log("プレイヤー：配信視聴　から抜けます");
        }

        public override void OnLeaveTriggered()
        {
            BackToPreviousState();
        }
    }
}
