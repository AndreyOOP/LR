namespace LodeRunner.Services.Rules
{
    using LodeRunner.Control;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class IsAbleMoveLeftRule : RuleBase
    {
        public IsAbleMoveLeftRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if (player.X == 0 ||
                intersection.Line<Brick>(Direction.Left, Side.Out, Operation.Or) ||
                intersection.Line<Stone>(Direction.Left, Side.Out, Operation.Or)
              )
            {
                player.SetImage(Textures.Stand);
                return false;
            }

            return true;
        }
    }
}
