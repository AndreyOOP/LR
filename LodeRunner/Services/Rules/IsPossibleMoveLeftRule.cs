namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class IsPossibleMoveLeftRule : RuleBase
    {
        Intersection intersection;

        public IsPossibleMoveLeftRule(Model model) : base (model)
        {
            intersection = new Intersection(model);
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
