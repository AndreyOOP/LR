using LodeRunner.Animation;
using LodeRunner.Services.Timer;

namespace LodeRunner.Model.SingleComponents
{
    public class Animations
    {
        public static AnimationImage Right { get; }     = new AnimationImage(Const.PlayerRightAnimation, Const.BlockSize, new MyTimer(200));
        public static AnimationImage Left { get; }      = new AnimationImage(Const.PlayerLeftAnimation, Const.BlockSize, new MyTimer(200));
        public static AnimationImage Fall { get; }      = new AnimationImage(Const.PlayerFallAnimation, Const.BlockSize, new MyTimer(200));
        public static AnimationImage Up { get; }        = new AnimationImage(Const.PlayerUpAnimation, Const.BlockSize, new MyTimer(200));
        public static AnimationImage RailLeft { get; }  = new AnimationImage(Const.PlayerRailLeftAnimation, Const.BlockSize, new MyTimer(200));
        public static AnimationImage RailRight { get; } = new AnimationImage(Const.PlayerRailRightAnimation, Const.BlockSize, new MyTimer(200));
        public static AnimationImage Burn { get; }      = new AnimationImage(Const.BrickBurnAnimation, Const.BlockSize, new MyTimer(200));
        public static AnimationImage Grow { get; }      = new AnimationImage(Const.BrickGrowAnimation, Const.BlockSize, new MyTimer(200));
        public static AnimationImage Water { get; }     = new AnimationImage(Const.WaterTexture, Const.BlockSize, new MyTimer(200));
    }
}
