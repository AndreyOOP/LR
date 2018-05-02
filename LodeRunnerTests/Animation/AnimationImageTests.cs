using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using LodeRunnerTests.Animation;
using LodeRunnerTests.VisualTester;
using System.Threading;

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
        public void x()
        {
            VisualStand vs = new VisualStand();
            vs.Start2();
        }

        [TestMethod]
        public void x1()
        {
            VisualStand vs = new VisualStand();
            vs.Start2();
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