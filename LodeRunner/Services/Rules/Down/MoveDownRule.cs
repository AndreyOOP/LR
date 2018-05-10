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
                (intersection.Line<Stairs>(Direction.Up, Side.In, Operation.And) ||
                intersection.Line<Stairs>(Direction.Down, Side.Out, Operation.And)) &&
                intersection.Get(Corner.BottomLeft) == intersection.Get(Corner.BottomRight)
              )
            {
                player.Y += 1;
                player.SetImage(Textures.StairsDown);
                player.Direction = Direction.None;
                return true;
            }
            else if(
                intersection.Get(Corner.BottomLeft, Direction.Down) != intersection.Get(Corner.BottomRight, Direction.Down) &&
                intersection.Get(Corner.BottomLeft, Direction.Down) is Stairs &&
                player.Direction == Direction.Left
                )
            {
                player.X -= 1;
                return true;
            }
            else if (
                intersection.Get(Corner.BottomRight, Direction.Down) is Stairs &&
                intersection.Get(Corner.BottomLeft, Direction.Down) != intersection.Get(Corner.BottomRight, Direction.Down) &&
                player.Direction == Direction.Right
                )
            {
                player.X += 1;
                return true;
            }

            player.SetImage(Textures.Stand);
            return false;
        }
    }
}