using System;
using System.Drawing;
using System.Timers;
using LodeRunner.Animation;

namespace LodeRunnerTests.Animation
{
    public class AnimationImageTestClass : AnimationImage
    {
        public AnimationImageTestClass(Bitmap animationImage, int frameLength, int speed) : base(animationImage, frameLength, speed)
        {
            timer.Elapsed += IncreaseTicksCounter;
        }

        public int TicksCounter { get; set; }

        public int CurrentFrame
        {
            get
            {
                return currentFrame;
            }
        }

        public Bitmap[] Frames
        {
            get
            {
                return frames;
            }
        }

        public Timer Timer
        {
            get
            {
                return timer;
            }
        }

        private void IncreaseTicksCounter(object sender, EventArgs e)
        {
            TicksCounter++;
        }
    }
}
