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
        List<SuperChatButton> superChatButtons = new List<SuperChatButton>();

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
                b.button.interactable = m_gc.Model.Player.Coins >= b.budget;
            }
        }

        void DeactivateSuperchatButton()
        {
            foreach (var b in superChatButtons)
            {
                b.button.interactable = false;
            }
        }

        public void EmitSuperchat(LeanButton sender)
        {
            // O(n)だけど無視
            foreach (var b in superChatButtons)
            {
                if (b.button != sender)
                {
                    continue;
                }

                // お金を消費してスパチャを投げる
                if (m_gc.Model.Player.Coins >= b.budget)
                {
                    m_gc.Model.Player.Coins -= b.budget;
                }
            }

            // ボタンのステートを更新
            ActivateSuperchatButton();
        }

        void OnBiasStateChanged(IStateMachine<BiasModel, BiasStateType> sender_, BiasStateType type)
        {
            var sender = sender_ as StateMachine<BiasModel, BiasState, BiasStateType>;

            // 配信中の場合
            switch (sender.State.Type)
            {
                case BiasStateType.Streaming:
                    Debug.Log("配信画面／UIコントローラー：　配信中");
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

    [System.Serializable]
    public class SuperChatButton
    {
        public LeanButton button;
        public int budget;
    }
}
