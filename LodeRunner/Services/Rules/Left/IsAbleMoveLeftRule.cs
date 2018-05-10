namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class IsAbleMoveLeftRule : RuleBase
    {
        public IsAbleMoveLeftRule(Model model) : base (model)
        {
        }

        public override bool Check()
        {
            if (player.X == 0 ||
                intersection.Line<Brick>(Direction.Left, Side.Out, Operation.Or) ||
                intersection.Line<Stone>(Direction.Left, Side.Out, Operation.Or)
              )
            {
                player.ActivatePlayerStand();
                return false;
            }

            return true;
        }
    }
}
