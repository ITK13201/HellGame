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
}
