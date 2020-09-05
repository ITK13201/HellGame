using HellGame.State;

namespace HellGame.Model
{
    public class BiasModel
    {
        // ステートマシン
        StateMachine<BiasModel, BiasState, BiasStateType> m_stateMachine;
        public StateMachine<BiasModel, BiasState, BiasStateType> StateMachine => m_stateMachine;

        public BiasModel()
        {
            // パラメタ類の初期化
            m_stateMachine = new StateMachine<BiasModel, BiasState, BiasStateType>();
            m_stateMachine.Target = this;
            m_stateMachine.NotifyNextState<BiasInactiveState>();
        }

        public void Update()
        {
            // ステートマシンの更新
            m_stateMachine.Update();
        }
    }
}
