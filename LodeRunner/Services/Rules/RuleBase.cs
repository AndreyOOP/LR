namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;

    public abstract class RuleBase : IRule
    {
        protected Model model;

        public RuleBase(Model model)
        {
            this.model = model;
        }

        public abstract bool Check();
    }
}
