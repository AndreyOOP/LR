namespace LodeRunner.Services.Rules.General
{
    using LodeRunner.Control;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class RightBurnRule : RuleBase
    {
        public RightBurnRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if(player.BlockX + 1 >= Const.BlockWidth)
            {
                return true;
            }

            var aboveBurn = model.Get((player.X + 10) / 20 + 1, player.BlockY);
            var burn = model.Get((player.X + 10)/20 + 1, player.BlockY+1);

            if (aboveBurn == null && burn is Brick)
            {
                var brick = (Brick)burn;

                if (brick.state == BrickState.Visible)
                {
                    brick.Burn();
                }
            }

            if (aboveBurn is Brick && burn is Brick)
            {
                var brick = (Brick)burn;

                if (brick.state == BrickState.Visible && ((Brick)aboveBurn).state == BrickState.NotVisible)
                {
                    brick.Burn();
                }

            }

            return true;
        }
    }
}
