using System;
using HellGame.Model;

namespace HellGame.State
{
    /// <summary>
    /// プレイヤーの状態のインターフェイス．
    /// </summary>
    public abstract class PlayerState : State<PlayerModel, PlayerStateType>
    {
    }

    public enum PlayerStateType
    {
        Normal,
        Babiniku,
    }

    public class PlayerNormalState : PlayerState
    {
        public override PlayerStateType Type => PlayerStateType.Normal;
    }

    public class PlayerBabinikuState : PlayerState
    {
        public override PlayerStateType Type => PlayerStateType.Babiniku;
    }
}
