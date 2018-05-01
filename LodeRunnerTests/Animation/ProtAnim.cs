using LodeRunner.Animation;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LodeRunnerTests.Animation
{
    //just to get access to inner model state
    class ProtAnim : AnimationImage
    {
        public ProtAnim(Bitmap imageWithAnimation, int frameLength, int speed, Timer timer) : base(imageWithAnimation, frameLength, speed, timer)
        {
        }

        public int GetCurrFrame()
        {
            return currentFrame;
        }
    }
}
