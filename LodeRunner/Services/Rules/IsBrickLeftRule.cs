namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Model.ModelComponents;

    public class IsBrickLeftRule : RuleBase
    {
        private Player player;

        public IsBrickLeftRule(Model model) : base(model)
        {
            player = model.Get<Player>(ComponentType.Player);
        }

        public override bool Check()
        {
            if (model.Get<ComponentsCollection<Brick>>(ComponentType.Brick).Get(player.X - Const.BlockSize, player.Y) != null)
            {
                player.ActivatePlayerStand();
                return false;
            }

            return true;
        }
    }
}
