namespace LodeRunner.Services.Command
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services.Rules;

    public class CommandA : CommandBase
    {
        public CommandA(Model model) : base(model)
        {
            Rules.Add(new IsInFieldLeftRule(model));
        }

        protected override void DoCommandAction()
        {
            var player = model.Get<Player>(ComponentType.Player);
            player.X -= 1;
            player.ActivateLeftAnimation();
        }
    }
}
