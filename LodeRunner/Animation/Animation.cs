using LodeRunner.Model.Interfaces;
using LodeRunner.Services.Timer;
using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace LodeRunner.Animation
{
    [Serializable]
    public class Animation : IAnimation, IPause
    {
        protected int currentFrame;
        protected Bitmap[] frames;
        protected ITimer myTimer;

        public Animation(string animationImagePath, int frameLength, ITimer myTimer)
        {
            var animationImage = new Bitmap(animationImagePath);
            ArgumentsCheck(animationImage, frameLength);

            frames = SplitImageOnFrames(animationImage, frameLength);

            this.myTimer = myTimer;
            this.myTimer.SetEventHandler(TimerTick);
        }

        public event EventHandler AnimationComplete;

        public void Start()
        {
            myTimer.Start();
        }

        public void Pause()
        {
            myTimer.Stop();
        }

        public void Continue()
        {
            myTimer.Resume();
        }

        public Bitmap GetCurrentFrame()
        {
            return frames[currentFrame];
        }

        private void ArgumentsCheck(Bitmap animationImage, int frameLength)
        {
            if (frameLength < 1)
            {
                throw new ArgumentException($"{nameof(frameLength)} has to be >= 1");
            }

            if (animationImage.Size.Width < frameLength)
            {
                throw new ArgumentException($"Width of {nameof(animationImage)} has to be longer than {nameof(frameLength)}");
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

        private void TimerTick(object sender, EventArgs e)
        {
            if (currentFrame++ >= frames.Length-1)
            {
                currentFrame = 0;
                AnimationComplete?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}