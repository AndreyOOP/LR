using LodeRunner.Model.SingleComponents;
using static LodeRunner.Services.Intersection;

namespace LodeRunner.Services.Rules.General
{
    public class OnRailRule : RuleBase
    {
        public OnRailRule(Model.Model model) : base(model)
        {
        }

        public override bool Check()
        {
            if (intersection.Line<Rail>(Direction.Up, Side.In, Operation.And))
            {
                player.SetImage(Textures.StairsDown);                
                return false;
            }

            return true;
        }
    }
}
