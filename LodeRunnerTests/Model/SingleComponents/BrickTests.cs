using System;
using LodeRunner;
using LodeRunner.Animation;
using LodeRunner.Model.SingleComponents;
using LodeRunnerTests;
using LodeRunnerTests.Animation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SingleComponents
{
    [TestClass]
    public class BrickTests
    {
        [TestMethod, Ignore]
        public void TestMethod1()
        {
            var tm = new TimerMock(200);

            var br = new Brick(0, 0);

            var prop = br.GetType().GetField("burn", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            prop.SetValue(br, new Animation(Const.BrickBurnAnimation, Const.BlockSize, new TimerMock(200)));

            br.Burn();
            tm.NextFrame();
            tm.NextFrame();
            tm.NextFrame();
            tm.NextFrame();
        }
    }
}
