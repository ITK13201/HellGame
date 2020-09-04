using System;

namespace HellGame.State
{
    public abstract class State<_Target, _StateType>
    {
        protected IStateMachine<_Target, _StateType> m_stateMachine;

        /// <summary>
        /// ステートのタイプ．
        /// </summary>
        abstract public _StateType Type { get; }

        /// <summary>
        /// ステートのターゲット．
        /// </summary>
        public _Target Target
        {
            get
            {
                return StateMachine.Target;
            }
        }
        /// <summary>
        /// ステートマシン．
        /// </summary>
        public IStateMachine<_Target, _StateType> StateMachine { get; set; }

        /// <summary>
        /// ステートに突入したときのイベント．
        /// </summary>
        public virtual void OnEnter() { }

        /// <summary>
        /// ステートから抜けるときのイベント．
        /// </summary>
        public virtual void OnExit() { }

        /// <summary>
        /// 更新時のイベント．
        /// </summary>
        public virtual void Update() { }
    }
}
