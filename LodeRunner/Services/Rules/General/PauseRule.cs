﻿using System.Collections.Generic;
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
                model.Unfreeze();
                controller.Commands.AllowedChars = Const.AllowedInput;
            }
            else
            {
                IsPaused = true;
                model.Freeze();
                controller.Commands.AllowedChars = Const.PauseInput;
            }

            return false;
        }
    }
}
