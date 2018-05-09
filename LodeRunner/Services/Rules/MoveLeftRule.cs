namespace LodeRunner.Services.Rules
{
    public class MoveLeftRule : RuleBase
    {
        public MoveLeftRule(Model.Model model) : base(model)
        {
        }

        public override bool Check()
        {
            player.X -= 1;
            player.ActivateLeftAnimation();
            return true;
        }
    }
}
