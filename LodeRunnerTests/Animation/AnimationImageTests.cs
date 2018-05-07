using System;
using System.Drawing;
using LodeRunnerTests.Animation;
using LodeRunnerTests.Model.SingleComponents;
using LodeRunnerTests.VisualTester;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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

        [TestMethod, Ignore]
        public void ManualAnimationDisplayTest()
        {
            ElementVisualizaer visualizer = new ElementVisualizaer();

            var animatedBitmap = new Bitmap(@"Animation\Files\AnimatedTestImage.png");
            var animation1     = new AnimationImage(animatedBitmap, 30, 50);
            var animation2     = new AnimationImage(animatedBitmap, 30, 150);

            animation1.Start();
            animation2.Start();
            
            visualizer.Add(new TestAnimationElement() { Animation = animation1, X = 0 , Y = 0});
            visualizer.Add(new TestAnimationElement() { Animation = animation2, X = 30, Y = 0 });

            visualizer.Start();
        }

        [TestMethod]
        public void IncorrectSpeedTest()
        {
            try
            {
                new AnimationImageTestClass(new Bitmap(10, 1), 1, 0);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("speed has to be >= 1", ex.Message);
            }
        }

        [TestMethod]
        public void IncorrectFrameLengthTest()
        {
            try
            {
                new AnimationImageTestClass(new Bitmap(10, 1), 0, 1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("frameLength has to be >= 1", ex.Message);
            }
        }

        [TestMethod]
        public void IncorrectImageToFrameLengthRatioTest()
        {
            try
            {
                new AnimationImageTestClass(new Bitmap(10, 10), 15, 1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual($"Width of animationImage has to be longer than frameLength", ex.Message);
            }
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