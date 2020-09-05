using System;
using UnityEngine;
using UnityEngine.UI;
using HellGame.State;
using HellGame.Model;

namespace HellGame.StreamingScene
{
    public class UIController : MonoBehaviour
    {
        GameController m_gameController;

        [SerializeField]
        Text m_statusDisplay;

        // int m_viewportWidth = 777;
        // int m_viewportHeight = 439;

        void Start()
        {
            m_gameController = GetComponent<GameController>();
            m_gameController.InitGame();
            
            m_gameController.Model.Bias.StateMachine.StateMachineTransition += OnBiasStateChanged;
        }

        void OnDestroy()
        {
            m_gameController.Model.Bias.StateMachine.StateMachineTransition -= OnBiasStateChanged;
        }

        void Update()
        {
            DisplayStatus();
        }

        void DisplayStatus()
        {
            switch (m_gameController.Model.Bias.StateMachine.State)
            {
                case BiasStreamingState s:
                    m_statusDisplay.text = $"配信中（合計{s.StreamingDuration}秒）: のこり{s.RemainingTime}秒";
                    break;
                case BiasInactiveState _:
                    m_statusDisplay.text = "オフライン";
                    break;
                case BiasPreparingState s:
                    m_statusDisplay.text = $"準備中：配信まで{s.TimeToReady}秒";
                    break;
                default:
                    throw new NotImplementedException("unreachable pattern!");
                    // break;
            }
        }

        void OnBiasStateChanged(IStateMachine<BiasModel, BiasStateType> sender_, BiasStateType type)
        {
            var sender = sender_ as StateMachine<BiasModel, BiasState, BiasStateType>;

            // 配信中の場合
            if (sender.State is BiasStreamingState s)
            {
                Debug.Log("配信中");
            }
        }
    }
}
