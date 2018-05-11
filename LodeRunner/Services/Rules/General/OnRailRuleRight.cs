using LodeRunner.Control;
using LodeRunner.Model.SingleComponents;
using static LodeRunner.Services.Intersection;

namespace LodeRunner.Services.Rules.General
{
    public class OnRailRuleRight : RuleBase
    {
        public OnRailRuleRight(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if (intersection.Line<Rail>(Direction.Up, Side.In, Operation.And))
            {
                player.SetAnimation(Animations.RailRight);
                return false;
            }

            return true;
        }
    }
}
