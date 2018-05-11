namespace LodeRunner.Services.Rules
{
    using LodeRunner.Control;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class IsAbleMoveDownRule : RuleBase
    {
        public IsAbleMoveDownRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if(
                player.Y > Const.WindowHeigth - Const.BlockSize - 1 ||
                intersection.Line<Brick>(Direction.Down, Side.Out, Operation.And) ||
                intersection.Line<Stone>(Direction.Down, Side.Out, Operation.And)
              )
            {
                player.SetImage(Textures.Stand);
                return false;
            }

            return true;
        }
    }
}
