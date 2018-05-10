using LodeRunner.Model.SingleComponents;
using static LodeRunner.Services.Intersection;

namespace LodeRunner.Services.Rules
{
    public class MoveUpRule : RuleBase
    {
        public MoveUpRule(Model.Model model) : base(model)
        {
        }

        public override bool Check()
        {
            if(
                (intersection.Line<Stairs>(Direction.Up, Side.In, Operation.And) ||
                intersection.Line<Stairs>(Direction.Down, Side.In, Operation.And)) &&
                intersection.Get(Corner.TopLeft) == intersection.Get(Corner.TopRight)
              )
            {
                player.Y -= 1;
                player.SetAnimation(Animations.Up);
                player.Direction = Direction.None;
                return true;
            }
            else if(
                intersection.Get(Corner.TopLeft) != intersection.Get(Corner.TopRight) &&
                intersection.Get(Corner.TopLeft) is Stairs &&
                player.Direction == Direction.Left
                )
            {
                player.X -= 1;
                return true;
            }
            else if (
                intersection.Get(Corner.TopLeft) != intersection.Get(Corner.TopRight) &&
                intersection.Get(Corner.TopRight) is Stairs &&
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