using LodeRunner.Model.ModelComponents;
using System;
using System.Drawing;

namespace LodeRunner.Model.SingleComponents
{
    [Serializable]
    public class Stone : StaticComponent
    {
        public Stone(int x = 0, int y = 0, Bitmap texture = null) : base(x, y, texture)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(texture, X, Y);
        }
    }
}
