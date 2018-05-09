namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;

    public abstract class RuleBase : IRule
    {
        protected Model model;
        protected Player player;

        public RuleBase(Model model)
        {
            this.model = model;
            player = model.Player;
        }

        public abstract bool Check();
    }
}
