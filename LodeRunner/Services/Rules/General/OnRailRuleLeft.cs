﻿using LodeRunner.Model.SingleComponents;
using static LodeRunner.Services.Intersection;

namespace LodeRunner.Services.Rules.General
{
    public class OnRailRuleLeft : RuleBase
    {
        public OnRailRuleLeft(Model.Model model) : base(model)
        {
        }

        public override bool Check()
        {
            if(intersection.Line<Rail>(Direction.Up, Side.In, Operation.And))
            {
                player.SetAnimation(Animations.RailLeft);
                return true;
            }

            return false;
        }
    }
}