using System;

namespace HellGame.State
{
    public interface IStateMachine<_Target, _StateType>
    {
        _Target Target { get; set; }

        void NotifyNextState<S>(S state)
            where S : State<_Target, _StateType>;

        void NotifyNextState<S>()
            where S : State<_Target, _StateType>, new();
    }

    public interface IStateMachineDelegate<_Target, _StateType>
    {
        void StateMachineTypeChanged(IStateMachine<_Target, _StateType> sender, _StateType type);
    }

    public class StateMachine<_Target, _State, _StateType>
        : IStateMachine<_Target, _StateType> where
        _State : State<_Target, _StateType>
    {
        private _Target m_target;
        private _State m_state;

        public _Target Target
        {
            get
            {
                return m_target;
            }

            set
            {
                m_target = value;
            }
        }

        public _State State => m_state;
        public IStateMachineDelegate<_Target, _StateType> Delegate = null;

        public void NotifyNextState<S>(S state)
            where S : State<_Target, _StateType>
        {
            var aState = state != null ? state as _State : null;
            if (m_state == aState || aState == null)
            {
                return;
            }

            if (m_state != null)
            {

                m_state.StateMachine = null;
            }

            aState.StateMachine = this;

            m_state?.OnExit();
            m_state = aState;
            state.OnEnter();

            Delegate?.StateMachineTypeChanged(this, m_state.Type);
        }

        public void NotifyNextState<S>()
            where S : State<_Target, _StateType>, new()
        {
            NotifyNextState(new S());
        }

        public void Update()
        {
            if (m_state == null)
            {
                return;
            }

            m_state.Update();
        }
    }
}
