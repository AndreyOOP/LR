namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using static LodeRunner.Services.Intersection;

    public class IsNotFallRule : RuleBase
    {
        public IsNotFallRule(Model model) : base(model)
        {
        }

        public override bool Check()
        {
            if(player.Y < Const.WindowHeigth - Const.BlockSize - 1 &&
               intersection.Line(Direction.Down, Side.Out, Operation.And) &&
               intersection.Line(Direction.Up, Side.In, Operation.And)
               )
            {
                player.Y += 1;
                player.ActivatePlayerFall();
                return false;
            }

            return true;
        }
    }
}