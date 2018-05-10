using LodeRunner.Model.SingleComponents;
using static LodeRunner.Services.Intersection;

namespace LodeRunner.Services.Rules
{
    public class MoveUpRule : RuleBase
    {
        public MoveUpRule(Model.Model model) : base(model)
        {
        }

        public override bool Check()
        {
            if(IsPlayerTopOrBottomOnSameStairs())
            {
                player.Y -= 1;
                player.SetAnimation(Animations.Up);
                player.Direction = Direction.None;
                return true;
            }

            if (IsTopAboveDiffBlocks() && IsAnyTopCornerOnStairs())
            {
                player.X += (player.Direction == Direction.Left) ? -1 : 1;
                return true;
            }

            player.SetImage(Textures.Stand);
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