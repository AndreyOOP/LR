using LodeRunner.Control;
using LodeRunner.Model.DynamicComponents;

namespace LodeRunner.Services.Rules
{
    public class NoInputRule : RuleBase
    {
        public NoInputRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            player.State = PlayerState.Stay;
            return true;
        }
    }
}
