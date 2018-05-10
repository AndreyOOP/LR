using LodeRunner.Model.SingleComponents;
using static LodeRunner.Services.Intersection;

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
            player.Direction = Direction.Right;
            return true;
        }
    }
}
