namespace LodeRunner.Services.Command
{
    using LodeRunner.Services.Rules;
    using System.Collections.Generic;
    using LodeRunner.Model;

    public abstract class CommandBase : ICommand
    {
        protected Model model;

        public List<IRule> Rules { get; set; } = new List<IRule>();

        public CommandBase(Model model)
        {
            this.model = model;
        }

        public void Execute()
        {
            foreach(var rule in Rules)
            {
                if (!rule.Check())
                {
                    return;
                }
            }
        }
    }
}
