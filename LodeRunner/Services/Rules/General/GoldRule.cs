using LodeRunner.Control;
using LodeRunner.Model.SingleComponents;

namespace LodeRunner.Services.Rules.General
{
    public class GoldRule : RuleBase
    {
        public GoldRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if(model.Get(model.Player.BlockX, model.Player.BlockY) is Gold)
            {
                model.Remove(model.Player.BlockX, model.Player.BlockY);
                model.Score++;

            }

            if (model.Get((model.Player.X+19)/20, model.Player.BlockY) is Gold)
            {
                model.Remove((model.Player.X + 19) / 20, model.Player.BlockY);
                model.Score++;
            }

            return true;
        }
    }
}
