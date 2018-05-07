namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;

    public class IsInFieldRightRule : RuleBase
    {
        private Player player;
        
        public IsInFieldRightRule(Model model) : base (model)
        {
            player = model.Get<Player>(ComponentType.Player);
        }

        public override bool Check()
        {
            return player.X < Const.WindowXSize - Const.BlockSize;
        }
    }
}
