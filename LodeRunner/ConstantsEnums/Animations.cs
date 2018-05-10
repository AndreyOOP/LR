using LodeRunner.Animation;
using System.Drawing;

namespace LodeRunner.Model.SingleComponents
{
    public class Animations
    {
        public static AnimationImage Right { get; }     = new AnimationImage(Const.PlayerRightAnimation, Const.BlockSize, 200);
        public static AnimationImage Left { get; }      = new AnimationImage(Const.PlayerLeftAnimation, Const.BlockSize, 200);
        public static AnimationImage Fall { get; }      = new AnimationImage(Const.PlayerFallAnimation, Const.BlockSize, 200);
        public static AnimationImage Up { get; }        = new AnimationImage(Const.PlayerUpAnimation, Const.BlockSize, 200);
        public static AnimationImage RailLeft { get; }  = new AnimationImage(Const.PlayerRailLeftAnimation, Const.BlockSize, 200);
        public static AnimationImage RailRight { get; } = new AnimationImage(Const.PlayerRailRightAnimation, Const.BlockSize, 200);

        
    }
}
