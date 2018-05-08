using LodeRunner.Model;
using LodeRunner.Model.ModelComponents;
using LodeRunner.Model.SingleComponents;

namespace LodeRunner.Services.Rules
{
    public class IsFallRule : RuleBase
    {
        private Player player;
        

        public IsFallRule(Model.Model model) : base(model)
        {
            player = model.Get<Player>(ComponentType.Player);
        }

        public override bool Check()
        {
            int x = (player.X / Const.BlockSize) * Const.BlockSize;
            int x2 = (player.X / Const.BlockSize + 1) * Const.BlockSize;
            int y = (player.Y / Const.BlockSize + 1) * Const.BlockSize;

            if ((model.Get<ComponentsCollection<Brick>>(ComponentType.Brick).Get(x, y) == null &&
               model.Get<ComponentsCollection<Brick>>(ComponentType.Brick).Get(x2, y) == null) &
               (model.Get<ComponentsCollection<Stairs>>(ComponentType.Stairs).Get(x, y) == null &&
               model.Get<ComponentsCollection<Stairs>>(ComponentType.Stairs).Get(x2, y) == null)
               )
            {
                player.Y += 1;
                player.ActivatePlayerFall();
                return false;
            }

            return true;
        }
    }
}
