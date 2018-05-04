using System.Drawing;
using LodeRunner.Animation;
using LodeRunner.Model.ModelComponents;

namespace LodeRunnerTests.Animation
{
    public class TestAnimationElement : SingleComponentBase
    {
        public AnimationImage Animation { get; set; }

        public TestAnimationElement()
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Animation.GetCurrentFrame(), X, Y);
        }
    }
}
