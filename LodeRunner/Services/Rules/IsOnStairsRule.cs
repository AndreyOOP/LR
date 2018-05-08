namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Model.ModelComponents;

    public class IsOnStairsRule : RuleBase
    {
        private Player player;

        public IsOnStairsRule(Model model) : base(model)
        {
            player = model.Get<Player>(ComponentType.Player);
        }

        public override bool Check()
        {
            int x = (player.X / Const.BlockSize) * Const.BlockSize;
            int y1 = (player.Y / Const.BlockSize) * Const.BlockSize;
            int y = (player.Y / Const.BlockSize + 1) * Const.BlockSize;

            if (model.Get<ComponentsCollection<Stairs>>(ComponentType.Stairs).Get(x, y) != null ||
                model.Get<ComponentsCollection<Stairs>>(ComponentType.Stairs).Get(x, y1) != null
                )
            {
                return true;
            }

            return false;
        }
    }
}
