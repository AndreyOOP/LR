using System;
using System.Drawing;
using System.Windows.Forms;

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

            if (animationImage.Size.Width >= frameLength)
                throw new ArgumentException($"Width of {nameof(animationImage)} has to be longer than {nameof(frameLength)}");

            if (speed < 1)
                throw new ArgumentException($"{nameof(speed)} has to be >= 1");

            timer = new Timer()
            {
                Enabled = false,
                Interval = speed
            };
            timer.Tick += TimerTick;

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
        }
    }
}