using LodeRunner.Model.ModelComponents;
using System;
using System.Drawing;

namespace LodeRunner.Model.SingleComponents
{
    [Serializable]
    public class Gold : SingleComponentBase
    {
        private static Bitmap texture = new Bitmap(Const.GoldTexture);

        public Gold(int x, int y) : base(x, y)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(texture, X, Y);
        }
    }
}
