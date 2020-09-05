using UnityEngine;
using HellGame.Model;

namespace HellGame.State
{
    public class BiasStreamingState : BiasState
    {
        public override BiasStateType Type => BiasStateType.Streaming;
        
        // 配信の準備時間
        float m_biasWaitTime = 10.0f;

        float m_initialWatingTime = 0.0f;

        public override void Update()
        {
            var g = GameController.Instance;
            var totalWait = g.Now - m_initialWatingTime;

            if (totalWait >= m_biasWaitTime)
            {
                StateMachine.NotifyNextState<BiasInactiveState>();
            }
        }

        public override void OnEnter()
        {
            Debug.Log("推し：配信中　へ変更します");
            
            var g = GameController.Instance;
            m_initialWatingTime = g.Now;
        }

        public override void OnExit()
        {
            Debug.Log("推し：配信中　から抜けます");
        }
    }
}
