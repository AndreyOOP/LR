namespace LodeRunnerTests.Animation
{
    using System.Drawing;
    using LodeRunner.Animation;
    using LodeRunner.Model.ModelComponents;

    public class TestAnimationElement : SingleComponentBase
    {
        public Animation Animation { get; set; }

        public TestAnimationElement()
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(Animation.GetCurrentFrame(), X, Y);
        }
    }
}
