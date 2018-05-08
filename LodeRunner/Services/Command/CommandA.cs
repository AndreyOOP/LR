namespace LodeRunner.Services.Command
{
    using LodeRunner.Model;
    using LodeRunner.Services.Rules;

    public class CommandA : CommandBase
    {
        public CommandA(Model model) : base(model)
        {
            Rules.Add(new IsFallRule(model));
            Rules.Add(new IsPossibleMoveLeftRule(model));
            Rules.Add(new MoveLeftRule(model));
        }
    }
}
