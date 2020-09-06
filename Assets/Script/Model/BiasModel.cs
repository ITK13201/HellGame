using HellGame.State;
using UnityEngine;

namespace HellGame.Model
{
    public delegate void UpdateMoneyDelegate(BiasModel sender, int delta);

    public class BiasModel
    {
        // ステートマシン
        StateMachine<BiasModel, BiasState, BiasStateType> m_stateMachine;
        public StateMachine<BiasModel, BiasState, BiasStateType> StateMachine => m_stateMachine;

        int m_moneyFromWishlist = 0;
        int m_moneyFromSuperchat = 0;

        public UpdateMoneyDelegate MoneyFromWishlistEvent = delegate {};
        public UpdateMoneyDelegate MoneyFromSuperchatEvent = delegate {};

        public int MoneyFromWishlist {
            get => m_moneyFromWishlist;
            set {
                var delta = value - m_moneyFromWishlist;
                Debug.Assert(delta >= 0, "推し：モデル　推しからお金を取ることはできません");

                Debug.Log($"推し：モデル　欲しいものリストから課金，{m_moneyFromSuperchat}→{value}");
                m_moneyFromWishlist = value;
                MoneyFromWishlistEvent(this, delta);
            }
        }

        public int MoneyFromSuperchat {
            get => m_moneyFromSuperchat;
            set {
                var delta = value - m_moneyFromSuperchat;
                Debug.Assert(delta >= 0, "推し：モデル　推しからお金を取ることはできません");

                Debug.Log($"推し：モデル　スーパーチャットから課金，{m_moneyFromSuperchat}→{value}");
                m_moneyFromSuperchat = value;
                MoneyFromSuperchatEvent(this, delta);
            }
        }

        public BiasModel()
        {
            // パラメタ類の初期化
            m_stateMachine = new StateMachine<BiasModel, BiasState, BiasStateType>();
            m_stateMachine.Target = this;
            m_stateMachine.NotifyNextState<BiasInactiveState>();
        }

        public void Update()
        {
            // ステートマシンの更新
            m_stateMachine.Update();
        }
    }
}
