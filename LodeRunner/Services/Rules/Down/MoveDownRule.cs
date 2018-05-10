namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class MoveDownRule : RuleBase
    {
        public MoveDownRule(Model model) : base(model)
        {
        }

        public override bool Check()
        {
            if(
                intersection.Line<Stairs>(Direction.Up, Side.In, Operation.And) ||
                intersection.Line<Stairs>(Direction.Down, Side.Out, Operation.And)
              )
            {
                player.Y += 1;
                player.SetImage(Textures.StairsDown);
                return true;
            }
            else if(intersection.Get(Corner.BottomLeft, Direction.Down) is Stairs) // need to add direction here to know how to react
            {
                player.X -= 1;
                player.SetImage(Textures.StairsDown);
                return true;
            }
            else if (intersection.Get(Corner.BottomRight, Direction.Down) is Stairs)
            {
                player.X += 1;
                player.SetImage(Textures.StairsDown);
                return true;
            }

            player.SetImage(Textures.Stand);
            return false;
        }
    }
}