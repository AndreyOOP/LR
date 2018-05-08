using LodeRunner.Model;
using LodeRunner.Model.SingleComponents;
using LodeRunner.Services.Rules;

namespace LodeRunner.Services.Command
{
    public class CommandD : CommandBase
    {
        public CommandD(Model.Model model) : base(model)
        {
            Rules.Add(new IsInFieldRightRule(model));
        }

        protected override void DoCommandAction()
        {
            var player = model.Get<Player>(ComponentType.Player);
            player.X += 1;
            player.ActivateRightAnimation();
        }
    }
}
