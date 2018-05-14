namespace LodeRunner.Model.SingleComponents
{
    using System.Drawing;
    using LodeRunner.Model.ModelComponents;

    public class GameOver : StaticComponent
    {
        public GameOver(int x, int y, Bitmap texture) : base(x, y, texture)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(texture, X, Y);
        }
    }
}
