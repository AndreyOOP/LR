﻿using LodeRunner.Model.SingleComponents;
using static LodeRunner.Services.Intersection;

namespace LodeRunner.Services.Rules
{
    public class MoveLeftRule : RuleBase
    {
        public MoveLeftRule(Model.Model model) : base(model)
        {
        }

        public override bool Check()
        {
            player.X -= 1;
            player.SetAnimation(Animations.Left);
            player.Direction = Direction.Left;
            return true;
        }
    }
}
