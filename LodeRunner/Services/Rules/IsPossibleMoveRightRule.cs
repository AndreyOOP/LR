﻿namespace LodeRunner.Services.Rules
{
    using LodeRunner.Model;
    using LodeRunner.Model.ModelComponents;
    using LodeRunner.Model.SingleComponents;

    public class IsPossibleMoveRightRule : RuleBase
    {   
        public IsPossibleMoveRightRule(Model model) : base (model)
        {
        }

        public override bool Check()
        {
            if((player.X >= Const.WindowXSize - Const.BlockSize) ||
               (RightLineCheck<Brick>())
              )
            {
                player.ActivatePlayerStand();
                return false;
            }

            return true;
        }

        private bool RightLineCheck<T>() where T : SingleComponentBase
        {
            int x1 = player.X+20;
            int y1 = player.Y;

            int x2 = player.X + 20;
            int y2 = player.Y + 19;

            int x1B = (x1 / 20);
            int y1B = (y1 / 20);

            int x2B = (x2 / 20);
            int y2B = (y2 / 20);

            return model.Get<T>().GetBlock(x1B, y1B) != null || model.Get<T>().GetBlock(x2B, y2B) != null;
        }
    }
}
