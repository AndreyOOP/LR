namespace LodeRunner.Services.Command
{
    using LodeRunner.Services.Rules;
    using System.Collections.Generic;
    using LodeRunner.Model;

    public abstract class CommandBase : ICommand
    {
        protected Model model;

        public List<IRule> Rules { get; set; }

        public CommandBase(Model model)
        {
            this.model = model;
            Rules = new List<IRule>();
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
            
            DoCommandAction();
        }

        protected abstract void DoCommandAction();
    }
}
