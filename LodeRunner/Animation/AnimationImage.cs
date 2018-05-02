using System;
using System.Drawing;

// using System.Timers instead of System.Windows.Forms
// Windows.Forms will work only if executed from the same thread - https://stackoverflow.com/questions/13412145/timer-wont-tick
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
            ArgumentsCheck(animationImage, frameLength, speed);

            timer = InitializeTimer(speed);

            frames = SplitImageOnFrames(animationImage, frameLength);
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

        private void ArgumentsCheck(Bitmap animationImage, int frameLength, int speed)
        {
            if (frameLength < 1)
            {
                throw new ArgumentException($"{nameof(frameLength)} has to be >= 1");
            }

            if (animationImage.Size.Width < frameLength)
            {
                throw new ArgumentException($"Width of {nameof(animationImage)} has to be longer than {nameof(frameLength)}");
            }

            if (speed < 1)
            {
                throw new ArgumentException($"{nameof(speed)} has to be >= 1");
            }
        }

        private Timer InitializeTimer(int speed)
        {
            timer = new Timer();
            timer.Enabled  = false;
            timer.Interval = speed;
            timer.Elapsed += TimerTick;

            return timer;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (++currentFrame >= frames.Length)
            {
                currentFrame = 0;
            }
        }

        private Bitmap[] SplitImageOnFrames(Bitmap animationImage, int frameLength)
        {
            Rectangle copyArea;
            var frames = new Bitmap[animationImage.Size.Width / frameLength];

            for (int i = 0; i < frames.Length; i++)
            {
                copyArea  = new Rectangle(i * frameLength, 0, frameLength, animationImage.Size.Height);
                frames[i] = animationImage.Clone(copyArea, animationImage.PixelFormat);
            }

            return frames;
        }
    }
}