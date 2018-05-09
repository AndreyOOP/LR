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
            if((model.Get(player.X/20, player.Y/20) is Stairs && 
                model.Get((player.X+19)/20, player.Y / 20) is Stairs) |
               (model.Get(player.X / 20, (player.Y+19) / 20) is Stairs &&
                model.Get((player.X + 19) / 20, (player.Y+19) / 20) is Stairs)
               )
            {
                player.Y -= 1;
                player.ActivatePlayerUp();
                return true;
            }
            else if (model.Get(player.BlockX, player.BlockY) is Stairs)
            {
                player.X -= 1;
                player.ActivatePlayerUp();
                return true;
            }
            else if (model.Get((player.X+19)/20, player.BlockY) is Stairs)
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
