using System;
using HellGame.Model;

namespace HellGame.State
{
    /// <summary>
    /// プレイヤーの状態のインターフェイス．
    /// </summary>
    public abstract class PlayerState : State<PlayerModel, PlayerStateType>
    {
        public virtual void OnCollide(object target) {}
    }

    public enum PlayerStateType
    {
        Normal,
        Babiniku,
    }
}
