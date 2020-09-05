using System;

namespace HellGame.Model
{
    public class GameModel
    {
        /// <summary>
        /// プレイヤーのモデル．
        /// </summary>
        private PlayerModel m_player;

        /// <summary>
        /// 推しのモデル．
        /// </summary>
        private BiasModel m_bias;

        public GameModel()
        {
            m_player = new PlayerModel();
            m_bias = new BiasModel();
        }

        public void Update()
        {
            m_player.Update();
            m_bias.Update();
        }
    }
}
