namespace LodeRunner.Services
{
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services.Timer;
    using LodeRunner.Animation;
    using System.Drawing;
    using LodeRunner.Model;
    using LodeRunner.Model.DynamicComponents;

    public class BlockFactory
    {
        public Brick GetBrick(int x, int y)
        {
            var brick = new Brick(x, y, new MyTimer(Const.BrickGrowPeriod));

            var growAnimation = new Animation(Const.BrickGrowAnimation, Const.BlockSize, new MyTimer(200));
            growAnimation.AnimationComplete += brick.OnGrowAnimationFinished;

            var burnAnimation = new Animation(Const.BrickBurnAnimation, Const.BlockSize, new MyTimer(200));
            burnAnimation.AnimationComplete += brick.OnBurnAnimationFinished;

            brick.AddDynamicState(BrickState.Burn, burnAnimation);
            brick.AddDynamicState(BrickState.Grow, growAnimation);
            brick.AddStaticState(BrickState.Visible, Textures.Brick);
            brick.AddStaticState(BrickState.NotVisible, new Bitmap(1, 1));

            brick.State = BrickState.Visible;

            return brick;
        }

        public Water GetWater(int x, int y)
        {
            var water = new Water(x, y);
            water.AddDynamicState(WaterState.Animated, Animations.Water);
            water.State = WaterState.Animated;
            return water;
        }

        public Stone GetStone(int x, int y)
        {
            return new Stone(x, y, Textures.Stone);
        }

        public Rail GetRail(int x, int y)
        {
            return new Rail(x, y, Textures.Rail);
        }

        public Stairs GetStairs(int x, int y)
        {
            return new Stairs(x, y, Textures.Stairs);
        }

        public Gold GetGold(int x, int y)
        {
            return new Gold(x, y, Textures.Gold);
        }

        public Player GetPlayer(int x, int y)
        {
            var player = new Player(x, y);

            player.AddDynamicState(PlayerState.RunLeft, Animations.Left);
            player.AddDynamicState(PlayerState.RailLeft, Animations.RailLeft);
            player.AddDynamicState(PlayerState.RunRight, Animations.Right);
            player.AddDynamicState(PlayerState.RailRight, Animations.RailRight);
            player.AddDynamicState(PlayerState.RunUp, Animations.Up);
            player.AddDynamicState(PlayerState.Fall, Animations.Fall);

            player.AddStaticState(PlayerState.RunDown, Textures.StairsDown);
            player.AddStaticState(PlayerState.Stay, Textures.Stand);

            player.State = PlayerState.Stay;

            return player;
        }

        public GameOver GetGameOver(int x, int y)
        {
            return new GameOver(x, y, Textures.GameOver);
        }
    }
}
