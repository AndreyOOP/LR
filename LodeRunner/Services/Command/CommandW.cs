

namespace LodeRunner.Services.Command
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services.Rules;

    public class CommandW : CommandBase
    {
        public CommandW(Model model) : base(model)
        {
            Rules.Add(new IsFallRule(model));
            Rules.Add(new IsOnStairsRule(model));
        }

        protected override void DoCommandAction()
        {
            var player = model.Get<Player>(ComponentType.Player);
            player.Y -= 1;
            player.ActivatePlayerUp();
        }
    }
}
