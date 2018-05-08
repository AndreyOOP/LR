using LodeRunner.Services.Rules;

namespace LodeRunner.Services.Command
{
    public class CommandD : CommandBase
    {
        public CommandD(Model.Model model) : base(model)
        {
            Rules.Add(new IsFallRule(model));
            Rules.Add(new IsPossibleMoveRightRule(model));
            Rules.Add(new MoveRightRule(model));
        }
    }
}
