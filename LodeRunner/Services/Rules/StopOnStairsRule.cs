using LodeRunner.Model.SingleComponents;

namespace LodeRunner.Services.Rules
{
    public class StopOnStairsRule : RuleBase
    {
        private bool isStopped = false;

        public StopOnStairsRule(Model.Model model) : base(model)
        {
        }

        public override bool Check()
        {
            if(model.Get<Stairs>().Get(player.X+1, player.Y) != null)
            {
                player.ActivatePlayerStand();

                return false;
            }

            return true;
        }
    }
}
