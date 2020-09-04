using System;
using HellGame.Model;

namespace HellGame.State
{
    /// <summary>
    /// 推しの状態のインターフェイス．
    /// </summary>
    public abstract class BiasState : State<PlayerModel, BiasStateType>
    {
    }

    public enum BiasStateType
    {
        Inactive,
        Preparing,
        Broadcasting,
    }

    public class BiasInactiveState : BiasState
    {
        public override BiasStateType Type => BiasStateType.Inactive;
    }

    public class BiasPreparingState : BiasState
    {
        public override BiasStateType Type => BiasStateType.Preparing;
    }

    public class BiasBroadcastingState : BiasState
    {
        public override BiasStateType Type => BiasStateType.Broadcasting;
    }
}
