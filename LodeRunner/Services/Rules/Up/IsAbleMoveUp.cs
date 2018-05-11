namespace LodeRunner.Services.Rules
{
    using LodeRunner.Control;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class IsAbleMoveUp : RuleBase
    {
        public IsAbleMoveUp(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if (
                player.Y <= 0 ||
                intersection.Line<Brick>(Direction.Up, Side.Out, Operation.And) ||
                intersection.Line<Stone>(Direction.Up, Side.Out, Operation.And)
              )
            {
                player.SetImage(Textures.Stand);
                return false;
            }

            return true;
        }
    }
}
