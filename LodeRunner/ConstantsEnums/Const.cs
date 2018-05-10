namespace LodeRunner
{
    public class Const
    {
        public static readonly string BrickTexture = @"Resources\Brick\Brick.png";
        public static readonly string BrickBurnAnimation = @"Resources\Brick\BrickBurnAnimation.png";
        public static readonly string BrickGrowAnimation = @"Resources\Brick\BrickGrowAnimation.png";

        public static readonly string PlayerFallAnimation = @"Resources\Player\FallAnimation.png";
        public static readonly string PlayerUpAnimation = @"Resources\Player\PlayerAnimationUp.png";
        public static readonly string PlayerLeftAnimation = @"Resources\Player\PlayerLeftAnimation.png";
        public static readonly string PlayerRightAnimation = @"Resources\Player\PlayerRightAnimation.png";
        public static readonly string PlayerStairsDown = @"Resources\Player\PlayerStairsDown.png";
        public static readonly string PlayerStand = @"Resources\Player\PlayerStand.png";
        public static readonly string PlayerRailLeftAnimation = @"Resources\Player\RailLeftAnimation.png";
        public static readonly string PlayerRailRightAnimation = @"Resources\Player\RailRightAnimation.png";

        public static readonly string GoldTexture = @"Resources\Gold.png";
        public static readonly string RailTexture = @"Resources\Rail.png";
        public static readonly string StairsTexture = @"Resources\Stairs.png";
        public static readonly string StoneTexture = @"Resources\Stone.png";
        public static readonly string WaterTexture = @"Resources\Water.png";

        public static readonly int BlockWidth = 20;
        public static readonly int BlockHeigth = 30;
        public static readonly int BlockSize = 20;

        public static readonly int WindowWidth = (BlockWidth) * BlockSize;// 450;
        public static readonly int WindowHeigth = (BlockHeigth) * BlockSize;
        public static readonly string WindowName = "Loderunner v0";

        public static readonly int FrameUpdatePeriod = 10;
        public static readonly int BrickGrowPeriod = 5000;



    }
}
