using UnityEngine;
using HellGame.Model;

namespace HellGame.State
{
    public class BiasInactiveState : BiasState
    {
        public override BiasStateType Type => BiasStateType.Inactive;
        
        // 配信の準備時間
        float m_biasWaitTime = 10.0f;

        float m_initialWatingTime = 0.0f;

        public override void Update()
        {
            var g = GameController.Instance;
            var totalWait = g.Now - m_initialWatingTime;

            if (totalWait >= m_biasWaitTime)
            {
                StateMachine.NotifyNextState<BiasPreparingState>();
            }
        }

        public override void OnEnter()
        {
            Debug.Log("推し：待ち　へ変更します");

            var g = GameController.Instance;
            m_initialWatingTime = g.Now;
        }

        public override void OnExit()
        {
            Debug.Log("推し：待ち　から抜けます");
        }
    }
}
