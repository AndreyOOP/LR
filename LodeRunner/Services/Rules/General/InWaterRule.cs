namespace LodeRunner.Services.Rules.General
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class InWaterRule : RuleBase
    {
        public InWaterRule(Model model) : base(model)
        {
        }

        public override bool Check()
        {
            if (IsTopOnWater())
            {
                model.SetMessage(new GameOver((Const.WindowWidth-200)/2, 100));
                model.IsGameOver = true;
                return false;
            }

            return true;
        }

        private bool IsTopOnWater()
        {
            return intersection.Line<Water>(Direction.Up, Side.In, Operation.Or);
        }
    }
}
