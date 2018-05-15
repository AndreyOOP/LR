namespace LodeRunner.Services.Rules
{
    using LodeRunner.Control;
    using LodeRunner.Model.DynamicComponents;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class MoveDownRule : RuleBase
    {
        public MoveDownRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if(IsPlayerTopOrBottomOnSameStairs() || IsPlayerOnRail())
            {
                player.Y += 1;
                player.State = PlayerState.RunDown;
                return true;
            }

            if (IsBottomAboveDiffBlocks() && IsAnyBottomCornerAboveStairs())
            {
                player.X += (player.State == PlayerState.RailLeft) ? -1 : 1;
                return true;
            }

            player.State = PlayerState.Stay;
            return true;
        }

        private bool IsPlayerTopOrBottomOnSameStairs()
        {
            return (intersection.Line<Stairs>(Direction.Up, Side.In, Operation.And) ||
                    intersection.Line<Stairs>(Direction.Down, Side.Out, Operation.And)) &&
                    intersection.Get(Corner.BottomLeft) == intersection.Get(Corner.BottomRight);
        }

        private bool IsPlayerOnRail()
        {
            return intersection.Line<Rail>(Direction.Down, Side.In, Operation.Or);
        }

        private bool IsBottomAboveDiffBlocks()
        {
            return intersection.Get(Corner.BottomLeft, Direction.Down) != intersection.Get(Corner.BottomRight, Direction.Down);
        }

        private bool IsAnyBottomCornerAboveStairs()
        {
            return intersection.Line<Stairs>(Direction.Down, Side.Out, Operation.Or);
        }
    }
}