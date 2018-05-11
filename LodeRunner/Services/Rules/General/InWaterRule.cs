namespace LodeRunner.Services.Rules.General
{
    using LodeRunner.Control;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using System.Collections.Generic;
    using static LodeRunner.Model.Model;
    using static LodeRunner.Services.Intersection;

    public class InWaterRule : RuleBase
    {
        public InWaterRule(Model model) : base(model)
        {
        }

        public InWaterRule(Model model, Controller controller) : base(model, controller)
        {
        }

        public override bool Check()
        {
            if (IsTopOnWater())
            {
                model.Message = new GameOver((Const.WindowWidth-200)/2, 100);
                model.Freeze();
                controller.Commands.AllowedChars = new HashSet<char>() { 'n' };

                // todo add model freeze
                return false;
            }

            return true;
        }

        private bool IsTopOnWater()
        {
            return intersection.Line<Water>(Direction.Up, Side.In, Operation.Or);
        }
    }
}
