using System;
using System.Drawing;
using System.Windows.Forms;

namespace LodeRunner.Animation
{
    public class AnimationImage : IAnimationImage
    {
        protected int      currentFrame; //if this will be public it will be possible to test or use reflection to check inner state
        private Bitmap[] frames;
        private Timer    timer;

        public AnimationImage(Bitmap imageWithAnimation, int frameLength, int speed, Timer timer)
        {
            if (imageWithAnimation.Size.Width % frameLength != 0)
            {
                throw new ArgumentException("inconsistens length of image & frame.."); //todo
            }
            //add exception if speed < 1 or frameLength < 1 ?

            this.timer = timer;
            //timer = new Timer() {
            //    Enabled  = false,
            //    Interval = speed
            //};
            timer.Enabled = false;
            timer.Interval = speed;
            timer.Tick += Timer_Tick;

            frames = new Bitmap[imageWithAnimation.Size.Width / frameLength];

            for (int i = 0; i < frames.Length; i++)
            {
                var copyArea = new Rectangle(i * frameLength, 0, frameLength, imageWithAnimation.Size.Height);

                frames[i] = imageWithAnimation.Clone(copyArea, imageWithAnimation.PixelFormat);
            }

            currentFrame = 0;
        }

        public void Start() //change to start & stop - check by inner function
        {
            //timer.Enabled = true;
            timer.Start();
        }

        public void Stop()
        {
            //timer.Enabled = false;
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

        private void Timer_Tick(object sender, EventArgs e)
        {
            currentFrame++;
        }
    }
}