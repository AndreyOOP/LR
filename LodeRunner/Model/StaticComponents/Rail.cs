using LodeRunner.Model.ModelComponents;
using System;
using System.Drawing;

namespace LodeRunner.Model.SingleComponents
{
    [Serializable]
    public class Rail : StaticComponent
    {
        private static Bitmap texture = new Bitmap(Const.RailTexture);

        public Rail(int x, int y) : base(x, y)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(texture, X, Y);
        }
    }
}
