﻿namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class IsNotFallRule : RuleBase
    {
        public IsNotFallRule(Model model) : base(model)
        {
        }

        public override bool Check()
        {
            if (IsInRail() || IsTopStairs() || IsInWater())
            {
                return true;
            }

            if (IsInGameWindow() && (IsBottomNullBlocks() || IsBelowRail() || IsAbovewWater()))
            {
                player.Y += 1;
                player.SetAnimation(Animations.Fall);
                return false;
            }

            return true;
        }

        private bool IsInGameWindow()
        {
            return player.Y < Const.WindowHeigth - Const.BlockSize - 1;
        }

        private bool IsBottomNullBlocks()
        {
            return intersection.Line(Direction.Down, Side.Out, Operation.And);
        }

        private bool IsTopStairs()
        {
            return intersection.Line<Stairs>(Direction.Up, Side.In, Operation.And);
        }

        private bool IsInRail()
        {
            var y = intersection.Get(Corner.TopLeft)?.Y ?? intersection.Get(Corner.TopRight)?.Y;
            return player.Y == y && intersection.Line<Rail>(Direction.Up, Side.In, Operation.Or);
        }

        private bool IsBelowRail()
        {
            return intersection.Line<Rail>(Direction.Down, Side.Out, Operation.Or);
        }

        private bool IsAbovewWater()
        {
            return intersection.Line<Water>(Direction.Down, Side.Out, Operation.Or);
        }

        private bool IsInWater()
        {
            var y = intersection.Get(Corner.TopLeft)?.Y ?? intersection.Get(Corner.TopRight)?.Y;
            return player.Y == y && intersection.Line<Water>(Direction.Up, Side.In, Operation.Or);
        }
    }
}