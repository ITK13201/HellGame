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

        float m_totalWait = 0.0f;

        public float StreamingDuration => m_biasWaitTime;

        public float RemainingTime => m_biasWaitTime - m_totalWait;

        public override void Update()
        {
            var g = GameController.Instance;
            m_totalWait = g.Now - m_initialWatingTime;

            if (m_totalWait >= m_biasWaitTime)
            {
                StateMachine.NotifyNextState<BiasInactiveState>();
            }
        }

        public override void OnEnter()
        {
            Debug.Log("推し：配信中　へ変更します");
            
            var g = GameController.Instance;

            m_initialWatingTime = g.Now;
            m_totalWait = 0.0f;
        }

        public override void OnExit()
        {
            Debug.Log("推し：配信中　から抜けます");
        }
    }
}
