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
            // todo logic which have to be burned
            var x = intersection.Get(Corner.BottomLeft, Direction.Down);

            if (x is Brick)
            {
                var brick = (Brick)x;

                if (brick.IsVisible)
                {
                    brick.Burn();
                }
            }

            return true;
        }
    }
}
