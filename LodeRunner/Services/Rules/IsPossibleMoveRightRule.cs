namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class IsPossibleMoveRightRule : RuleBase
    {
        Intersection intersection;

        public IsPossibleMoveRightRule(Model model) : base (model)
        {
            intersection = new Intersection(model);
        }

        public override bool Check()
        {
            if((player.X >= Const.WindowXSize - Const.BlockSize) ||
               intersection.Line<Brick>(Direction.Right, Side.Out, Operation.Or) ||
               intersection.Line<Stone>(Direction.Right, Side.Out, Operation.Or)
              )
            {
                player.ActivatePlayerStand();
                return false;
            }

            return true;
        }
    }
}
