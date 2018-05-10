namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;

    public abstract class RuleBase : IRule
    {
        protected Model model;
        protected Player player;
        protected Intersection intersection;

        public RuleBase(Model model)
        {
            this.model = model;
            player = model.Player;
            intersection = new Intersection(model);
        }

        public abstract bool Check();
    }
}
