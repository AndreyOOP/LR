using Microsoft.VisualStudio.TestTools.UnitTesting;
using LodeRunner.Animation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace LodeRunner.Animation.Tests
{
    [TestClass()]
    public class AnimationImageTests
    {
        [TestMethod()]
        public void StartTest()
        {
            var timer = new Timer();
            var animation = new AnimationImage(new Bitmap(1, 1), 1, 10, timer);

            animation.Start();

            Assert.IsTrue(timer.Enabled);

            animation.Stop();

            Assert.IsFalse(timer.Enabled);

            animation.Reset();
            //assert get inner state ?

            //add tick function on timer e.g. count

            //add inner function which just counts timer activations, monitor it in cycle

            //while not activated 5 do, then get current state
        }

        //add visual testing only - bitmap & see how animation plays
    }
}