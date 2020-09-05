using System;
using UnityEngine;
using Lean.Gui;
using HellGame.State;
using HellGame.Model;
using System.Collections.Generic;

namespace HellGame.StreamingScene
{
    public class UIController : MonoBehaviour
    {
        GameController m_gc;

        readonly int m_viewportWidth = 777;
        // int m_viewportHeight = 439;

        [SerializeField]
        RectTransform seekBar = null;
        
        [SerializeField]
        List<LeanButton> superChatButtons = new List<LeanButton>();

        void Start()
        {
            m_gc = GameController.EnsureGame;
            var m = m_gc.Model.Bias.StateMachine;

            m.StateMachineTransition += OnBiasStateChanged;

            // 初期化
            OnBiasStateChanged(m, m.State.Type);
        }

        void OnDestroy()
        {
            m_gc.Model.Bias.StateMachine.StateMachineTransition -= OnBiasStateChanged;
            m_gc = null;
        }

        void Update()
        {
            DisplayStatus();
        }

        void DisplayStatus()
        {
            var m = m_gc.Model.Bias.StateMachine;

            if (m.State is BiasStreamingState s)
            {
                // シークバーの更新
                seekBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 
                    (1 - s.RemainingTime / s.StreamingDuration) * m_viewportWidth
                );
            }
        }

        void ActivateSuperchatButton()
        {
            foreach (var b in superChatButtons)
            {
                b.interactable = true;
            }
        }

        void DeactivateSuperchatButton()
        {
            foreach (var b in superChatButtons)
            {
                b.interactable = false;
            }
        }

        void OnBiasStateChanged(IStateMachine<BiasModel, BiasStateType> sender_, BiasStateType type)
        {
            var sender = sender_ as StateMachine<BiasModel, BiasState, BiasStateType>;

            // 配信中の場合
            switch (sender.State.Type)
            {
            case BiasStateType.Streaming:
                Debug.Log("配信中");
                ActivateSuperchatButton();
                break;
            case BiasStateType.Inactive:
                seekBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
                DeactivateSuperchatButton();
                break;
            case BiasStateType.Preparing:
                seekBar.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 0);
                DeactivateSuperchatButton();
                break;
            default:
                // unreachable!()
                break;
            }
        }
    }
}
