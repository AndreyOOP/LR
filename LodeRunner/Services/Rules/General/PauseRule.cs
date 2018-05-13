using LodeRunner.Control;

namespace LodeRunner.Services.Rules.General
{
    public class PauseRule : RuleBase
    {
        private bool IsPaused = false;

        public PauseRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if (IsPaused)
            {
                IsPaused = false;
                model.Continue();
                controller.Commands.AllowedChars = Const.AllowedInput;
            }
            else
            {
                IsPaused = true;
                model.Pause();
                controller.Commands.AllowedChars = Const.PauseInput;
            }

            return false;
        }
    }
}
