namespace LodeRunner.Services.Command
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;

    public class CommandD : ICommand
    {
        private Model model; // todo think about static model, as well add some base class for more easy extension

        public CommandD(Model model)
        {
            this.model = model;
        }

        public void Execute()
        {
            var player = model.Get<Player>(ComponentType.Player);

            player.X += 1;
        }
    }
}
