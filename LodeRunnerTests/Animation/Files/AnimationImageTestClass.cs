using LodeRunner.Animation;
using System;
using System.Drawing;
using System.Timers;


namespace LodeRunnerTests.Animation
{
    public class AnimationImageTestClass : AnimationImage
    {
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

        public AnimationImageTestClass(Bitmap animationImage, int frameLength, int speed) : base(animationImage, frameLength, speed)
        {
            timer.Elapsed += IncreaseTicksCounter;
        }

        private void IncreaseTicksCounter(object sender, EventArgs e)
        {
            TicksCounter++;
        }
    }
}
