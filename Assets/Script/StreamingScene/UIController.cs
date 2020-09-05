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
