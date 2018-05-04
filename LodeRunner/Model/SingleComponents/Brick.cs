using LodeRunner.Model.ModelComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodeRunner.Model.BaseClasses
{
    public class Brick : SingleComponentBase
    {
        private static Bitmap image;

        public Brick()
        {
            //image = new Bitmap("path to brick image");
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(image, X, Y);
        }
    }
}
