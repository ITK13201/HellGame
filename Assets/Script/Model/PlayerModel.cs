﻿using UnityEngine;
using HellGame.State;

namespace HellGame.Model
{
    public delegate void UpdateCoinsEventDelegate(PlayerModel sender, int coins);
    public delegate void UpdateBoostEventDelegate(PlayerModel sender, int boost);

    public class PlayerModel
    {
        // ステートマシン
        StateMachine<PlayerModel, PlayerState, PlayerStateType> m_stateMachine;
        public StateMachine<PlayerModel, PlayerState, PlayerStateType> StateMachine => m_stateMachine;

        // 初期値など
        const int kPlayerModelInitialCoins = 100000;
        const int kPlayerModelInitialBoost = 0;

        // 内部状態
        int m_coins = kPlayerModelInitialCoins;
        int m_boost = kPlayerModelInitialBoost;

        // アクセサー．ここからビューに通知が送られる

        /// <summary>
        /// 所有しているコインの数．
        /// </summary>
        public int Coins
        {
            get => m_coins;
            set
            {
                Debug.Assert(value >= 0, "プレイヤー：モデル　＜エラー＞コイン数は正である必要があります．");
                
                if (m_coins > value)
                {
                    Debug.Log($"プレイヤー：モデル　コインを消費します {m_coins} → {value}");
                }
                else if (m_coins < value)
                {
                    Debug.Log($"プレイヤー：モデル　コインが追加されました {m_coins} → {value}");
                }
                else
                {
                    Debug.Log("コインの残高に変化はありません．");
                    return; 
                }

                m_coins = value;
                UpdateCoinsEvent(this, m_coins);
            }
        }

        /// <summary>
        /// ブースト．神絵師の腕を食うと増える．
        /// </summary>
        public int Boost
        {
            get => m_boost;
            set
            {
                Debug.Assert(value >= 0, "プレイヤー：モデル　＜エラー＞ブーストは正値である必要があります．");

                m_boost = value;
                UpdateBoostEvent(this, m_boost);
            }
        }

        // デリゲート
        public UpdateCoinsEventDelegate UpdateCoinsEvent = delegate {};
        public UpdateBoostEventDelegate UpdateBoostEvent = delegate {};

        public PlayerModel()
        {
            // パラメタ類の初期化
            m_stateMachine = new StateMachine<PlayerModel, PlayerState, PlayerStateType>();
            m_stateMachine.Target = this;
            m_stateMachine.NotifyNextState<PlayerNormalState>();

            m_coins = kPlayerModelInitialCoins;
            m_boost = kPlayerModelInitialBoost;
        }

        public void Update()
        {
            // ステートマシンの更新
            m_stateMachine.Update();
        }
    }

    public interface IPlayerModelDelegate
    {
        void PlayerModelUpdateCoins(PlayerModel sender, int coins);

        void PlayerModelUpdateBoost(PlayerModel sender, int boost);
    }
}
