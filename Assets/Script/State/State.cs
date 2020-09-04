namespace HellGame.State
{
    public abstract class State<_Target, _StateType> : IState
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

        public virtual void OnEnter() { }

        public virtual void OnExit() { }

        public virtual void Update() { }

        public virtual void OnMessage(IMessage _) { }
    }

    public interface IState {
        /// <summary>
        /// ステートに突入したときのイベント．
        /// </summary>
        void OnEnter();

        /// <summary>
        /// ステートから抜けるときのイベント．
        /// </summary>
        void OnExit();

        /// <summary>
        /// 更新時のイベント．
        /// </summary>
        void Update();

        /// <summary>
        /// メッセージを処理する．
        /// </summary>
        void OnMessage(IMessage message);
    }

    public interface IMessage {}
}
