using System;
using HellGame.Model;

namespace HellGame.State
{
    /// <summary>
    /// プレイヤーの状態のインターフェイス．
    /// </summary>
    public abstract class PlayerState : State<PlayerModel, PlayerStateType>
    {
        public virtual void OnCollide(object target) { }

        public virtual void OnWatchTriggered()
        {
            if (Type == PlayerStateType.Watching)
            {
                return;
            }

            // TODO: 配信中かチェック

            // 配信視聴モードに移行
            StateMachine.NotifyNextState(new PlayerWatchingState(this));
        }

        public virtual void OnLeaveTriggered() { }
    }

    public enum PlayerStateType
    {
        Normal,
        Babiniku,
        Watching,
    }
}
