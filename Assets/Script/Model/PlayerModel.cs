using System;
using HellGame.State;

namespace HellGame.Model
{
    public class PlayerModel
    {
        StateMachine<PlayerModel, PlayerState, PlayerStateType> m_stateMachine;

        public PlayerModel()
        {
        }

        public void Init()
        {
            // パラメタ類の初期化
            m_stateMachine = new StateMachine<PlayerModel, PlayerState, PlayerStateType>();
            m_stateMachine.Target = this;
            m_stateMachine.NotifyNextState(new PlayerNormalState());
        }
    }
}
