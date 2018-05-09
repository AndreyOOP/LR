namespace LodeRunner.Services.Command
{
    using LodeRunner.Services.Rules;
    using System.Collections.Generic;
    using System.Collections;

    public class Command : ICommand, IEnumerable<IRule>
    {
        public List<IRule> Rules { get; set; } = new List<IRule>();

        public Command()
        {
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

        public IEnumerator<IRule> GetEnumerator()
        {
            foreach (var x in Rules)
            {
                yield return x;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Rules.GetEnumerator();
        }
    }
}
