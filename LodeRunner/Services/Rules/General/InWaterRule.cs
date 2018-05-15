namespace LodeRunner.Services.Rules.General
{
    using LodeRunner.Control;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using static LodeRunner.Services.Intersection;

    public class InWaterRule : RuleBase
    {
        public InWaterRule(Controller controller) : base(controller)
        {
        }

        public override bool Check()
        {
            if (IsTopOnWater() || IsTopInBrick())
            {
                model.Message = new GameOver((Const.WindowWidth-200)/2, 100, Textures.GameOver);
                model.Pause();
                controller.Commands.AllowedChars = Const.GameOverInput;

                return false;
            }

            return true;
        }

        private bool IsTopOnWater()
        {
            return intersection.Line<Water>(Direction.Up, Side.In, Operation.Or);
        }

        private bool IsTopInBrick()
        {
            var element = intersection.Get(Corner.TopLeft);

            if(element is Brick)
            {
                if (((Brick)element).State == BrickState.Visible)
                {
                    model.Player.SetImage(Textures.StairsDown); //todo change to ? nothing ? In Brick ?
                    return true;
                }
            }

            return false;
        }
    }
}
