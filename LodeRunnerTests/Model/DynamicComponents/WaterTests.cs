namespace LodeRunner.Model.SingleComponents.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunnerTests.VisualTester;
    using LodeRunner.Model.DynamicComponents;
    using System.Collections.Generic;
    using LodeRunner.Animation;

    [TestClass]
    public class WaterTests
    {
        [TestMethod]
        public void DrawTest()
        {
            var visualizer = new ElementVisualizaer();

            var d = new Dictionary<WaterState, Animation>();
            d.Add(WaterState.Animated, Animations.Water);

            visualizer.Add(new Water(0, 0, d, null, WaterState.Animated));
            visualizer.Add(new Water(20, 0, d, null, WaterState.Animated));
            visualizer.Add(new Water(20, 20, d, null, WaterState.Animated));

            visualizer.Start();
        }
    }
}