namespace LodeRunner.Services.Command
{
    using LodeRunner.Model;
    using LodeRunner.Services.Rules;

    public class CommandW : CommandBase
    {
        public CommandW(Model model) : base(model)
        {
            Rules.Add(new IsFallRule(model));
            //Rules.Add(new IsOnStairsRule(model));
            Rules.Add(new MoveUpRule(model));
        }
    }
}
