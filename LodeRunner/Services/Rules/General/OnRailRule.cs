using LodeRunner.Control;
using LodeRunner.Model.DynamicComponents;
using LodeRunner.Model.SingleComponents;
using static LodeRunner.Services.Intersection;

namespace LodeRunner.Services.Rules.General
{
    public class OnRailRule : RuleBase
    {
        public OnRailRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if (intersection.Line<Rail>(Direction.Up, Side.In, Operation.And))
            {
                player.State = PlayerState.RunDown;
                return false;
            }

            return true;
        }
    }
}
