using LodeRunner.Animation;
using LodeRunner.Model.ModelComponents;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LodeRunner.Model
{
    public class Water : SingleComponentBase
    {
        private static AnimationImage image = new AnimationImage(null, 10, 1); // todo ...

        public override void Draw(Graphics g)
        {
            g.DrawImage(image.GetCurrentFrame(), X, Y);
        }
    }
}
