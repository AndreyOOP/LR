namespace LodeRunner.Services.Command
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;

    public class CommandA : ICommand
    {
        private Model model;

        public CommandA(Model model)
        {
            this.model = model;
        }

        public void Execute()
        {
            var player = model.Get<Player>(ComponentType.Player);
            player.X -= 1;
        }
    }
}
