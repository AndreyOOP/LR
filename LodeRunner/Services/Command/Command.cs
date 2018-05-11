namespace LodeRunner.Services.Command
{
    using LodeRunner.Services.Rules;
    using System.Collections.Generic;
    using System.Collections;

    public class Command : ICommand, IEnumerable<IRule>
    {
        private bool isContinious;

        public List<IRule> Rules { get; set; } = new List<IRule>();

        public Command(bool isContinious = true)
        {
            this.isContinious = isContinious;
        }
        
        public void Add(IRule rule)
        {
            Rules.Add(rule);
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

        public bool IsContinious()
        {
            return isContinious;
        }

        public IEnumerator<IRule> GetEnumerator()
        {
            foreach (var rule in Rules)
            {
                yield return rule;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Rules.GetEnumerator();
        }
    }
}
