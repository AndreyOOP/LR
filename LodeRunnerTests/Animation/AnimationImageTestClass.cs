using LodeRunner.Animation;
using System.Drawing;
using System.Timers;


namespace LodeRunnerTests.Animation
{
    public class AnimationImageTestClass : AnimationImage
    {
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

        public AnimationImageTestClass(Bitmap animationImage, int frameLength, int speed) : base(animationImage, frameLength, speed){}
    }
}
