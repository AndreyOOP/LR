namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class IsAbleMoveRightRule : RuleBase
    {
        public IsAbleMoveRightRule(Model model) : base (model)
        {
        }

        public override bool Check()
        {
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
    }
}
