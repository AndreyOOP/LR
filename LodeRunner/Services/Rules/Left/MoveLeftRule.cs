using LodeRunner.Control;
using LodeRunner.Model.DynamicComponents;
using LodeRunner.Model.SingleComponents;
using static LodeRunner.Services.Intersection;

namespace LodeRunner.Services.Rules
{
    public class MoveLeftRule : RuleBase
    {
        public MoveLeftRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            player.X -= 1;
            player.State = PlayerState.RunLeft;
            return true;
        }
    }
}
