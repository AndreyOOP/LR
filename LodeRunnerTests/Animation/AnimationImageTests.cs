using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using LodeRunnerTests.Animation;
using LodeRunnerTests.VisualTester;

namespace LodeRunner.Animation.Tests
{
    [TestClass]
    public class AnimationImageTests
    {
        private AnimationImageTestClass animationImage;

        [TestInitialize]
        public void Initialize()
        {
            animationImage = new AnimationImageTestClass(new Bitmap(10, 1), 1, 1);
        }

        [TestMethod]
        public void StartTest()
        {
            animationImage.Start();
            Assert.IsTrue(animationImage.Timer.Enabled);
        }

        [TestMethod]
        public void StopTest()
        {
            animationImage.Stop();
            Assert.IsFalse(animationImage.Timer.Enabled);
        }

        [TestMethod]
        public void ResetTest()
        {
            AnimateTillFrame(5);
            animationImage.Reset();
            Assert.AreEqual(0, animationImage.CurrentFrame);
        }

        [TestMethod]
        public void CurrentFrameTest()
        {
            AnimateTillFrame(0);
            Assert.AreEqual(0, animationImage.CurrentFrame);

            AnimateTillFrame(5);
            Assert.AreEqual(5, animationImage.CurrentFrame);

            AnimateTillFrame(10);
            Assert.AreEqual(0, animationImage.CurrentFrame);

            AnimateTillFrame(14);
            Assert.AreEqual(4, animationImage.CurrentFrame);
        }

        [TestMethod]
        public void ManualAnimationDisplayTest()
        {
            ElementVisualizaer visualizer = new ElementVisualizaer();

            var animatedBitmap = new Bitmap(@"Animation\Files\AnimatedTestImage.png");
            var animation1     = new AnimationImage(animatedBitmap, 30, 50);
            var animation2     = new AnimationImage(animatedBitmap, 30, 150);

            visualizer.Add(new TestAnimationElement(animation1, new Point( 0, 0)));
            visualizer.Add(new TestAnimationElement(animation2, new Point(30, 0)));

            visualizer.Start();
        }

        private void AnimateTillFrame(int qty)
        {
            animationImage.Start();

            while (animationImage.TicksCounter != qty)
            {
            }
            animationImage.Stop();
        }
    }
}