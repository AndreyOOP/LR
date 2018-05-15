﻿namespace LodeRunner.Services.Rules
{
    using LodeRunner.Control;
    using LodeRunner.Model.DynamicComponents;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class IsAbleMoveLeftRule : RuleBase
    {
        public IsAbleMoveLeftRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if (IsAbleMoveInTransparentBrick())
            {
                return true;
            }

            if (player.X == 0 ||
                intersection.Line<Brick>(Direction.Left, Side.Out, Operation.Or) ||
                intersection.Line<Stone>(Direction.Left, Side.Out, Operation.Or)
              )
            {
                player.State = PlayerState.Stay;
                return false;
            }

            return true;
        }

        private bool IsAbleMoveInTransparentBrick()
        {
            var el = intersection.Get(Corner.TopLeft, Direction.Left);

            if(el is Brick)
            {
                var brick = (Brick)el;
                return brick.State == BrickState.Burn || brick.State == BrickState.NotVisible;
            }

            return false;
        }
    }
}
