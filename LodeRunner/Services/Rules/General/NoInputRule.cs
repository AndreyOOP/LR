using LodeRunner.Model.SingleComponents;

namespace LodeRunner.Services.Rules
{
    public class NoInputRule : RuleBase
    {
        public NoInputRule(Model.Model model) : base(model)
        {
        }

        public override bool Check()
        {
            player.SetImage(Textures.Stand);
            return true;
        }
    }
}
