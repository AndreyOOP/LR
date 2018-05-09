namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.ModelComponents;
    using LodeRunner.Model.SingleComponents;

    public class IsPossibleMoveLeftRule : RuleBase
    {
        public IsPossibleMoveLeftRule(Model model) : base (model)
        {
        }

        public override bool Check()
        {
            if (player.X == 0 ||
                LeftLineCheck()
              )
            {
                player.ActivatePlayerStand();
                return false;
            }

            return true;
        }

        private bool LeftLineCheck()
        {
            int x1 = player.X-1;
            int y1 = player.Y;

            int x2 = player.X-1;
            int y2 = player.Y + 19;

            int x1B = (x1 / 20);
            int y1B = (y1 / 20);

            int x2B = (x2 / 20);
            int y2B = (y2 / 20);

            return model.Get(x1B, y1B) is Brick || model.Get(x2B, y2B) is Brick;
        }
    }
}
