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

        public void NotifyNextState<S>(S state)
            where S : State<_Target, _StateType>
        {
            var aState = state != null ? state as _State : null;
            if (m_state == aState || aState == null)
            {
                return;
            }

            m_state?.OnExit();
            m_state = aState;
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
