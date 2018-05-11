﻿namespace LodeRunner.Services.Rules.General
{
    using LodeRunner.Control;
    using LodeRunner.Model.SingleComponents;

    public class LeftBurnRule : RuleBase
    {
        public LeftBurnRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if(player.BlockX - 1 < 0)
            {
                return true;
            }

            var aboveBurn = model.Get((player.X + 10)/20 - 1, player.BlockY);
            var burn = model.Get((player.X + 10) / 20 - 1, player.BlockY+1);

            if (aboveBurn == null && burn is Brick)
            {
                var brick = (Brick)burn;

                if (brick.IsVisible)
                {
                    brick.Burn();
                }
            }

            if (aboveBurn is Brick && burn is Brick)
            {
                var brick = (Brick)burn;

                if (brick.IsVisible && !((Brick)aboveBurn).IsVisible)
                {
                    brick.Burn();
                }

            }

            return true;
        }
    }
}