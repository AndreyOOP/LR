using LodeRunner.Model.ModelComponents;
using System.Drawing;

namespace LodeRunner.Model.SingleComponents
{
    public class Player : SingleComponentBase
    {
        private static Rectangle rectangle = new Rectangle(0, 0, 20, 20);

        public override void Draw(Graphics g)
        {
            rectangle.Location = new Point(X, Y);
            g.DrawRectangle(Pens.Black, rectangle);
        }
    }
}
