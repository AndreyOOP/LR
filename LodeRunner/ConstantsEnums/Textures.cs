using System.Drawing;

namespace LodeRunner
{
    public class Textures
    {
        public static Bitmap Stand { get; }      = new Bitmap(Const.PlayerStand);
        public static Bitmap StairsDown { get; } = new Bitmap(Const.PlayerStairsDown);
        public static Bitmap Gold { get; }       = new Bitmap(@"Resources\Gold.png");
        public static Bitmap GameOver { get; }   = new Bitmap(@"Resources\GameOver.png");
        public static Bitmap Brick { get; }      = new Bitmap(Const.BrickTexture);
        public static Bitmap Stone { get; }      = new Bitmap(Const.StoneTexture);
        public static readonly Bitmap Rail       = new Bitmap(Const.RailTexture);
        public static readonly Bitmap Stairs     = new Bitmap(Const.StairsTexture);
    }
}
