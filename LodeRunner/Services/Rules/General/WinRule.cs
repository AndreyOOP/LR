using LodeRunner.Control;
using LodeRunner.Model.SingleComponents;

namespace LodeRunner.Services.Rules.General
{
    public class WinRule : RuleBase
    {
        public WinRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if(model.MaxScore == model.Score)
            {
                model.Pause();
                model.Message = new GameOver(10, 10);
                controller.Commands.AllowedChars = Const.PauseInput;
            }

            return true;
        }
    }
}
