namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class IsAbleMoveDownRule : RuleBase
    {
        public IsAbleMoveDownRule(Model model) : base(model)
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
