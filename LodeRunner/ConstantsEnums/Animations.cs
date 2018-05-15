namespace LodeRunner.Model.SingleComponents
{
    using LodeRunner.Animation;
    using LodeRunner.Services.Timer;

    public class Animations
    {
        public static Animation Right { get; }     = new Animation(Const.PlayerRightAnimation, Const.BlockSize, new MyTimer(200));
        public static Animation Left { get; }      = new Animation(Const.PlayerLeftAnimation, Const.BlockSize, new MyTimer(200));
        public static Animation Fall { get; }      = new Animation(Const.PlayerFallAnimation, Const.BlockSize, new MyTimer(200));
        public static Animation Up { get; }        = new Animation(Const.PlayerUpAnimation, Const.BlockSize, new MyTimer(200));
        public static Animation RailLeft { get; }  = new Animation(Const.PlayerRailLeftAnimation, Const.BlockSize, new MyTimer(200));
        public static Animation RailRight { get; } = new Animation(Const.PlayerRailRightAnimation, Const.BlockSize, new MyTimer(200));
        public static Animation Burn { get; }      = new Animation(Const.BrickBurnAnimation, Const.BlockSize, new MyTimer(200));
        public static Animation Grow { get; }      = new Animation(Const.BrickGrowAnimation, Const.BlockSize, new MyTimer(200));
        public static Animation Water { get; }     = new Animation(Const.WaterTexture, Const.BlockSize, new MyTimer(200));
    }
}
