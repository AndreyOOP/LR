namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using static LodeRunner.Services.Intersection;

    public class IsNotFallRule : RuleBase
    {
        private Intersection intersection;

        public IsNotFallRule(Model model) : base(model)
        {
            intersection = new Intersection(model);
        }

        public override bool Check()
        {
            if(intersection.Line(Direction.Down, Side.Out, Operation.And))
            {
                player.Y += 1;
                player.ActivatePlayerFall();
                return false;
            }

            return true;
        }
    }
}