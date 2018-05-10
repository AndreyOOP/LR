using LodeRunner.Model.SingleComponents;

namespace LodeRunner.Services.Rules
{
    public class MoveRightRule : RuleBase
    {
        public MoveRightRule(Model.Model model) : base(model)
        {
        }

        public override bool Check()
        {
            player.X += 1;
            player.SetAnimation(Animations.Right);
            return true;
        }
    }
}
