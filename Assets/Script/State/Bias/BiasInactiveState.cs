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
            // m_biasWaitTimeを課金額から算出
            m_biasWaitTime = CalcBiasWaitTime();
            Debug.Log($"推し：待ち　へ変更します．予定待ち時間は，{m_biasWaitTime} 秒です");

            var g = GameController.Instance;
            m_initialWatingTime = g.Now;

            Target.MoneyFromWishlistEvent += UpdateWaitTime;
        }

        public override void OnExit()
        {
            Target.MoneyFromWishlistEvent -= UpdateWaitTime;
            Debug.Log("推し：待ち　から抜けます");
        }

        void UpdateWaitTime(BiasModel sender, int _delta)
        {
            m_biasWaitTime = CalcBiasWaitTime();
            Debug.Log($"推し：待ち　予定待ち時間が{m_biasWaitTime} 秒に更新されました");
        }

        float CalcBiasWaitTime() => 20.0f / Mathf.Log(2.0f + Target.MoneyFromWishlist * 6.0e-6f);
    }
}
