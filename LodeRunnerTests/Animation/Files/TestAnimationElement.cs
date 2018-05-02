using System.Drawing;
using LodeRunner;
using LodeRunner.Animation;

namespace LodeRunnerTests.Animation
{
    public class TestAnimationElement : VisualElement
    {
        private AnimationImage animationImage;

        public TestAnimationElement(AnimationImage animationImage, Point position)
        {
            this.animationImage = animationImage;
            Position = position;

            animationImage.Start();
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(animationImage.GetCurrentFrame(), Position);
        }
    }
}
