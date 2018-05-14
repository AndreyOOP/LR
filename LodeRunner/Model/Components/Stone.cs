using LodeRunner.Model.ModelComponents;
using System;
using System.Drawing;

namespace LodeRunner.Model.SingleComponents
{
    [Serializable]
    public class Stone : StaticComponent
    {
        public static Bitmap Image { get; set; } = new Bitmap(Const.StoneTexture);

        public Stone(int x, int y) : base(x, y)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Image, X, Y);
        }
    }
}
