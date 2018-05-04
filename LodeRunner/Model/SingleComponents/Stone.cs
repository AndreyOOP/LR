using LodeRunner.Model.ModelComponents;
using System.Drawing;

namespace LodeRunner.Model.SingleComponents
{
    public class Stone : SingleComponentBase
    {
        public static Bitmap Image { get; set; } = new Bitmap(Const.StoneTexture);

        public override void Draw(Graphics g)
        {
            g.DrawImage(Image, X, Y);
        }
    }
}
