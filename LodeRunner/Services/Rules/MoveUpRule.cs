using LodeRunner.Model.SingleComponents;

namespace LodeRunner.Services.Rules
{
    // todo add tests
    public class MoveUpRule : RuleBase
    {
        public MoveUpRule(Model.Model model) : base(model)
        {
        }

        public override bool Check()
        {
            if(model.Get<Stairs>().Get(player.X, ((player.Y+19)/20)*20) != null || 
               model.Get<Stairs>().Get(player.X, (player.Y / 20) * 20) != null)
            {
                player.Y -= 1;
                player.ActivatePlayerUp();
                return true;
            }
            else if (model.Get<Stairs>().GetBlock(player.BlockX, player.BlockY) != null)
            {
                player.X -= 1;
                player.ActivatePlayerUp();
                return true;
            }
            else if (model.Get<Stairs>().GetBlock(player.BlockX+1, player.BlockY) != null)
            {
                player.X += 1;
                player.ActivatePlayerUp();
                return true;
            }

            player.ActivatePlayerStand();
            return false;
        }
    }
}
