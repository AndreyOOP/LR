namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Model.ModelComponents;

    public class IsBrickRightRule : RuleBase
    {
        private Player player;

        public IsBrickRightRule(Model model) : base(model)
        {
            player = model.Get<Player>(ComponentType.Player);
        }

        public override bool Check()
        {
            if (model.Get<ComponentsCollection<Brick>>(ComponentType.Brick).Get(player.X + Const.BlockSize, player.Y) != null)
            {
                player.ActivatePlayerStand();
                return false;
            }

            return true;
        }
    }
}
