namespace LodeRunner.Services.Rules
{
    using LodeRunner.Control;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;

    public abstract class RuleBase : IRule
    {
        protected Model model;
        protected Player player;
        protected Intersection intersection; //todo move out of class
        protected Controller controller;

        public RuleBase(Model model)
        {
            this.model = model;
            player = model.Player;
            intersection = new Intersection(model);
        }

        public RuleBase(Model model, Controller controller) : this(model)
        {
            this.controller = controller;
        }

        public abstract bool Check();
    }
}
