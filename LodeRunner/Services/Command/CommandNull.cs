namespace LodeRunner.Services.Command
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;

    public class CommandNull : CommandBase
    {
        private Player player;

        public CommandNull(Model model) : base(model)
        {
            player = model.Get<Player>(ComponentType.Player);
        }

        protected override void DoCommandAction()
        {
            player.Animation.Stop();
        }
    }
}
