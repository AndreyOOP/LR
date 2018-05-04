using LodeRunner.Model.ModelComponents;
using LodeRunner.Animation;
using System.Drawing;

namespace LodeRunner.Model.SingleComponents
{
    public class Player : SingleComponentBase
    {
        private static Rectangle rectangle = new Rectangle(0, 0, 20, 20);
        private static AnimationImage texture = new AnimationImage(new Bitmap(Const.WaterTexture), 20, 200);

        static Player()
        {
            texture.Start();
        }

        public override void Draw(Graphics g)
        {
            //rectangle.Location = new Point(X, Y);
            //g.DrawRectangle(Pens.Black, rectangle);

            g.DrawImage(texture.GetCurrentFrame(), X, Y);
        }
    }
}
