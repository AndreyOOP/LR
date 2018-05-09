using LodeRunner.Model.SingleComponents;
using static LodeRunner.Services.Intersection;

namespace LodeRunner.Services.Rules
{
    public class MoveUpRule : RuleBase
    {
        private Intersection intersection;

        public MoveUpRule(Model.Model model) : base(model)
        {
            intersection = new Intersection(model);
        }

        public override bool Check()
        {
            if(
                intersection.Line<Stairs>(Direction.Up, Side.In, Operation.And) ||
                intersection.Line<Stairs>(Direction.Down, Side.In, Operation.And)
                // todo add same level
              )
            {
                player.Y -= 1;
                player.ActivatePlayerUp();
                return true;
            }
            else if(intersection.Get(Corner.TopLeft) is Stairs) // need to add direction here to know how to react
            {
                player.X -= 1;
                player.ActivatePlayerUp();
                return true;
            }
            else if (intersection.Get(Corner.TopRight) is Stairs)
            {
                player.X += 1;
                player.ActivatePlayerUp();
                return true;
            }

            player.ActivatePlayerStand();
            return false;
        }
    }
}