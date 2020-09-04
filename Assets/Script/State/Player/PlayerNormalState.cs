using System;
using HellGame.Model;

namespace HellGame.State
{
    public class PlayerNormalState : PlayerState
    {
        public override PlayerStateType Type => PlayerStateType.Normal;

        public override void Update()
        {
            // いろいろ...
        }
    }
}
