namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class MoveDownRule : RuleBase
    {
        public MoveDownRule(Model model) : base(model)
        {
        }

        public override bool Check()
        {
            if(IsPlayerTopOrBottomOnSameStairs() || IsPlayerOnRail())
            {
                player.Y += 1;
                player.SetImage(Textures.StairsDown);
                player.Direction = Direction.None;
                return true;
            }

            if (IsBottomAboveDiffBlocks() && IsAnyBottomCornerAboveStairs())
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
                    intersection.Line<Stairs>(Direction.Down, Side.Out, Operation.And)) &&
                    intersection.Get(Corner.BottomLeft) == intersection.Get(Corner.BottomRight);
        }

        private bool IsPlayerOnRail()
        {
            return intersection.Line<Rail>(Direction.Down, Side.In, Operation.And);
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