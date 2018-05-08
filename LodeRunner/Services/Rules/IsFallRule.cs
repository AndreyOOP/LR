namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.ModelComponents;
    using LodeRunner.Model.SingleComponents;

    public class IsFallRule : RuleBase
    {
        public IsFallRule(Model model) : base(model)
        {
        }

        public override bool Check()
        {
            if(BottomLineCheck<Brick>() && BottomLineCheck<Stairs>() && BottomLineCheck<Stone>())
            {
                player.Y += 1;
                player.ActivatePlayerFall();
                return false;
            }

            return true;
        }

        private bool BottomLineCheck<T>() where T : SingleComponentBase
        {
            int x1 = player.X;
            int y1 = player.Y + 20;

            int x2 = player.X+19;
            int y2 = player.Y + 20;

            int x1B = (x1 / 20);
            int y1B = (y1 / 20);

            int x2B = (x2 / 20);
            int y2B = (y2 / 20);

            return model.Get<T>().GetBlock(x1B, y1B) == null && model.Get<T>().GetBlock(x2B, y2B) == null;
        }
    }
}