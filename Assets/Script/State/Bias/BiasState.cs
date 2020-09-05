using System;
using HellGame.Model;

namespace HellGame.State
{
    /// <summary>
    /// 推しの状態のインターフェイス．
    /// </summary>
    public abstract class BiasState : State<BiasModel, BiasStateType>
    {
        public bool IsStreaming => Type == BiasStateType.Streaming;
    }

    public enum BiasStateType
    {
        Inactive,
        Preparing,
        Streaming,
    }
}
