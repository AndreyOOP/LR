namespace LodeRunner.Services.Rules
{
    using LodeRunner.Control;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class IsNotFallRule : RuleBase
    {
        public IsNotFallRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if (IsInRail() || IsTopStairs() || IsInWater())
            {
                return true;
            }

            if (IsInGameWindow() && (IsBottomNullBlocks() || IsBelowRail() || IsAbovewWater() || IsBelowTransperantBrick() || IsBelowGold()))
            {
                player.Y += 1;
                player.SetAnimation(Animations.Fall);
                return false;
            }

            return true;
        }

        private bool IsBelowTransperantBrick()
        {
            var element1 = intersection.Get(Corner.BottomRight, Direction.Down);
            var element2 = intersection.Get(Corner.BottomLeft, Direction.Down);

            if (element1 is Brick && element2 is Brick)
            {
                return ((Brick)element1).IsTransparent && ((Brick)element2).IsTransparent;
            }

            return false;
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
            return intersection.Line<Water>(Direction.Down, Side.Out, Operation.And);
        }

        private bool IsInWater()
        {
            var y = intersection.Get(Corner.TopLeft)?.Y ?? intersection.Get(Corner.TopRight)?.Y;
            return player.Y == y && intersection.Line<Water>(Direction.Up, Side.In, Operation.Or);
        }

        private bool IsBelowGold()
        {
            return intersection.Line<Gold>(Direction.Down, Side.Out, Operation.Or);
        }
    }
}