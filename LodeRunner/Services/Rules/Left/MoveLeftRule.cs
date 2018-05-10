using LodeRunner.Model.SingleComponents;

namespace LodeRunner.Services.Rules
{
    public class MoveLeftRule : RuleBase
    {
        public MoveLeftRule(Model.Model model) : base(model)
        {
        }

        public override bool Check()
        {
            player.X -= 1;
            player.SetAnimation(Animations.Left);
            return true;
        }
    }
}
