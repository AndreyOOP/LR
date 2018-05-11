using LodeRunner.Control;

namespace LodeRunner.Services.Rules
{
    public class NoInputRule : RuleBase
    {
        public NoInputRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            player.SetImage(Textures.Stand);
            return true;
        }
    }
}
