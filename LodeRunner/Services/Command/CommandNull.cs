namespace LodeRunner.Services.Command
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services.Rules;

    public class CommandNull : CommandBase
    {
        private Player player;

        public CommandNull(Model model) : base(model)
        {
            player = model.Get<Player>(ComponentType.Player);
            Rules.Add(new IsFallRule(model));
            Rules.Add(new NoInputRule(model));
        }
    }
}
