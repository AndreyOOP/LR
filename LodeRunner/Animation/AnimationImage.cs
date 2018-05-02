using System;
using System.Drawing;

// using System.Timers instead of System.Windows.Forms
// Windows.Forms will work only if executed from the same thread, details - https://stackoverflow.com/questions/13412145/timer-wont-tick
using System.Timers;

namespace LodeRunner.Animation
{
    public class AnimationImage : IAnimationImage
    {
        protected int      currentFrame;
        protected Bitmap[] frames;
        protected Timer    timer;

        public AnimationImage(Bitmap animationImage, int frameLength, int speed)
        {
            if (frameLength < 1)
                throw new ArgumentException($"{nameof(frameLength)} has to be >= 1");

            if (animationImage.Size.Width < frameLength)
                throw new ArgumentException($"Width of {nameof(animationImage)} has to be longer than {nameof(frameLength)}");

            if (speed < 1)
                throw new ArgumentException($"{nameof(speed)} has to be >= 1");

            timer = new Timer() {
                Enabled = false,
                Interval = speed
            };
            timer.Elapsed += TimerTick;

            frames = new Bitmap[animationImage.Size.Width / frameLength];

            for (int i = 0; i < frames.Length; i++)
            {
                var copyArea = new Rectangle(i * frameLength, 0, frameLength, animationImage.Size.Height);
                frames[i] = animationImage.Clone(copyArea, animationImage.PixelFormat);
            }
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Reset()
        {
            currentFrame = 0;
        }

        public Bitmap GetCurrentFrame()
        {
            return frames[currentFrame];
        }

        private void TimerTick(object sender, EventArgs e)
        {
            currentFrame++;

            if (currentFrame > frames.Length)
                currentFrame = 0;
        }
    }
}