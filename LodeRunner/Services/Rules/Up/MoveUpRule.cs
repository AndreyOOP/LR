using LodeRunner.Control;
using LodeRunner.Model.DynamicComponents;
using LodeRunner.Model.SingleComponents;
using static LodeRunner.Services.Intersection;

namespace LodeRunner.Services.Rules
{
    public class MoveUpRule : RuleBase
    {
        public MoveUpRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if (IsPlayerTopOrBottomOnSameStairs())
            {
                player.Y -= 1;
                player.State = PlayerState.RunUp;
                return true;
            }

            if (IsTopAboveDiffBlocks() && IsAnyTopCornerOnStairs())
            {
                player.X += (player.State == PlayerState.RunLeft) ? -1 : 1;
                return true;
            }

            player.State = PlayerState.Stay;
            return false;
        }

        private bool IsPlayerTopOrBottomOnSameStairs()
        {
            return (intersection.Line<Stairs>(Direction.Up, Side.In, Operation.And) ||
                    intersection.Line<Stairs>(Direction.Down, Side.In, Operation.And)) &&
                    intersection.Get(Corner.TopLeft) == intersection.Get(Corner.TopRight);
        }

        private bool IsTopAboveDiffBlocks()
        {
            return intersection.Get(Corner.TopLeft) != intersection.Get(Corner.TopRight);
        }

        private bool IsAnyTopCornerOnStairs()
        {
            return intersection.Line<Stairs>(Direction.Up, Side.In, Operation.Or);
        }
    }
}