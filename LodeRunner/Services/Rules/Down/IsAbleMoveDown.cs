namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class IsAbleMoveDown : RuleBase
    {
        public IsAbleMoveDown(Model model) : base(model)
        {
        }

        public override bool Check()
        {
            if(
                player.Y >= Const.WindowHeigth ||
                intersection.Line<Brick>(Direction.Down, Side.Out, Operation.Or) ||
                intersection.Line<Stone>(Direction.Down, Side.Out, Operation.Or)
              )
            {
                player.ActivatePlayerStand();
                return false;
            }

            return true;
        }
    }
}
