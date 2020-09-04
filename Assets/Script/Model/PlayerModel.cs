using System;
using HellGame.State;

namespace HellGame.Model
{
    public class PlayerModel
    {
        // ステートマシン
        StateMachine<PlayerModel, PlayerState, PlayerStateType> m_stateMachine;

        // 初期値など
        const int kPlayerModelInitialCoins = 10000;
        const int kPlayerModelInitialBoost = 0;

        // 内部状態
        int m_coins = kPlayerModelInitialCoins;
        int m_boost = kPlayerModelInitialBoost;

        // アクセサー．ここからビューに通知が送られる
        public int Coins {
            get => m_coins;
            set {
                m_coins = value;
                Delegate?.PlayerModelUpdateCoins(this, m_coins);
            }
        }

        public int Boost {
            get => m_boost;
            set {
                m_boost = value;
                Delegate?.PlayerModelUpdateBoost(this, m_boost);
            }
        }

        // デリゲート
        public IPlayerModelDelegate Delegate = null;

        public PlayerModel()
        {
            // パラメタ類の初期化
            m_stateMachine = new StateMachine<PlayerModel, PlayerState, PlayerStateType>();
            m_stateMachine.Target = this;
            m_stateMachine.NotifyNextState(new PlayerNormalState());

            m_coins = kPlayerModelInitialCoins;
            m_boost = kPlayerModelInitialBoost;
        }

        public void Update() {
            // ステートマシンの更新
            m_stateMachine.Update();
        }
    }

    public interface IPlayerModelDelegate {
        void PlayerModelUpdateCoins(PlayerModel sender, int coins);

        void PlayerModelUpdateBoost(PlayerModel sender, int boost);
    }
}
