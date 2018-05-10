namespace LodeRunner.Services.Rules.General
{
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class BurnRule : RuleBase
    {
        public BurnRule(Model model) : base(model)
        {
        }

        public override bool Check()
        {
            var x = intersection.Get(Corner.BottomLeft, Direction.Down);
            if (x is Brick)
            {
                ((Brick)x).Burn();
            }

            return true;
        }
    }
}
