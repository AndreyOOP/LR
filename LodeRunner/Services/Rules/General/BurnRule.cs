namespace LodeRunner.Services.Rules.General
{
    using LodeRunner.Control;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class BurnRule : RuleBase
    {
        public BurnRule(Controller controller) : base(controller)
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
