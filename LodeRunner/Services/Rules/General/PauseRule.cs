using System.Collections.Generic;
using LodeRunner.Control;

namespace LodeRunner.Services.Rules.General
{
    public class PauseRule : RuleBase
    {
        private bool IsPaused = false;

        public PauseRule(Model.Model model, Controller controller) : base(model, controller)
        {
        }

        public override bool Check()
        {
            if (IsPaused)
            {
                IsPaused = false;
                model.UnFreeze();
                controller.Commands.AllowedChars = Const.AllowedInput;// new HashSet<char>() { 'a', 'd', 'w', 's', 'q', ' ', 'n', 'p' }; //todo move to enums
            }
            else
            {
                IsPaused = true;
                model.Freeze();
                controller.Commands.AllowedChars = Const.PauseInput;// new HashSet<char>() { 'n', 'p' }; ////todo move to enums
            }

            return false;
        }
    }
}
