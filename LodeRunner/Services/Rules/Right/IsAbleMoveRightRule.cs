namespace LodeRunner.Services.Rules
{
    using LodeRunner.Control;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class IsAbleMoveRightRule : RuleBase
    {
        public IsAbleMoveRightRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if (IsAbleMoveInTransparentBrick())
            {
                return true;
            }

            if ((player.X > Const.WindowWidth - Const.BlockSize - 1) ||
               intersection.Line<Brick>(Direction.Right, Side.Out, Operation.Or) ||
               intersection.Line<Stone>(Direction.Right, Side.Out, Operation.Or)
              )
            {
                player.SetImage(Textures.Stand);
                return false;
            }

            return true;
        }

        private bool IsAbleMoveInTransparentBrick()
        {
            var el = intersection.Get(Corner.TopRight, Direction.Left);

            if (el is Brick)
            {
                return ((Brick)el).IsTransparent;
            }

            return false;
        }
    }
}
