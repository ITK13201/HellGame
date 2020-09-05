using UnityEngine;
using HellGame;
using HellGame.Model;

namespace HellGame.State
{
    public class BiasPreparingState : BiasState
    {
        public override BiasStateType Type => BiasStateType.Preparing;
        
        // 配信の準備時間
        const float kBiasPreparingTime = 10.0f;

        float m_initialWatingTime = 0.0f;
        float m_totalWait = 0.0f;

        public float TimeToReady => kBiasPreparingTime - m_totalWait;

        public override void Update()
        {
            var g = GameController.Instance;
            m_totalWait = g.Now - m_initialWatingTime;

            if (m_totalWait >= kBiasPreparingTime)
            {
                StateMachine.NotifyNextState<BiasStreamingState>();
            }
        }

        public override void OnEnter()
        {
            Debug.Log("推し：配信準備　へ変更します");

            var g = GameController.Instance;
            
            m_initialWatingTime = g.Now;
            m_totalWait = 0;
        }

        public override void OnExit()
        {
            Debug.Log("推し：配信準備　から抜けます");
        }
    }
}
