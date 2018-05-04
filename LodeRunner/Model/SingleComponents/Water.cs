using LodeRunner.Animation;
using LodeRunner.Model.ModelComponents;
using System.Drawing;

namespace LodeRunner.Model
{
    public class Water : SingleComponentBase
    {
        public static AnimationImage Image { get; set; } 

        static Water()
        {
            Image = new AnimationImage(new Bitmap(Const.WaterTexture), 20, 200);
            Image.Start();
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Image.GetCurrentFrame(), X, Y);
        }
    }
}
