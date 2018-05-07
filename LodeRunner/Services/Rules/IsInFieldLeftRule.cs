namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;

    public class IsInFieldLeftRule : RuleBase
    {
        private Player player;

        public IsInFieldLeftRule(Model model) : base (model)
        {
            player = model.Get<Player>(ComponentType.Player);
        }

        public override bool Check()
        {
            if(player.X <= 0)
            {
                player.ActivatePlayerStand();
                return false;
            }

            return true;
        }
    }
}
