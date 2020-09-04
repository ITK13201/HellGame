using System;

namespace HellGame.State
{
    public interface IStateMachine<_Target, _StateType>
    {
        _Target Target { get; set; }

        void NotifyNextState<S>(S state)
            where S : State<_Target, _StateType>;
    }

    public class StateMachine<_Target, _State, _StateType>
        : IStateMachine<_Target, _StateType> where
        _State : State<_Target, _StateType>
    {
        private _Target m_target;
        private State<_Target, _StateType> m_state;

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

        public void NotifyNextState<S>(S state)
            where S : State<_Target, _StateType>
        {
            if (m_state == state || state == null)
            {
                return;
            }

            m_state?.OnExit();
            m_state = state;
            state.OnEnter();
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
