namespace AnimationTests
{
    using System;
    using System.Drawing;
    using LodeRunner.Animation;
    using LodeRunner.Services.Timer;

    public class AnimationImageTestClass : Animation
    {
        public AnimationImageTestClass(string animationImagePath, int frameLength, ITimer timer) : base(animationImagePath, frameLength, timer)
        {
            timer.SetEventHandler(IncreaseTicksCounter);
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

        public ITimer Timer
        {
            get
            {
                return myTimer;
            }
        }

        private void IncreaseTicksCounter(object sender, EventArgs e)
        {
            TicksCounter++;
        }
    }
}
