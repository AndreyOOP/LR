using Microsoft.VisualStudio.TestTools.UnitTesting;
using LodeRunner.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using LodeRunnerTests.Animation;
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
            animationImage = new AnimationImageTestClass(new Bitmap(10, 1), 1, 10);
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
        public void x() //todo 
        {
            animationImage.Start();

            for(int i=0; i<15; i++)
            {
                Thread.Sleep(20);
                Console.WriteLine(animationImage.CurrentFrame);
            }
                
            //while (animationImage.CurrentFrame != 5) { }

            //Assert.AreEqual(5, animationImage.CurrentFrame);
        }
    }
}