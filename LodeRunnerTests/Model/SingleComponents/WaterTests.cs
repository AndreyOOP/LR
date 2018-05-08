using Microsoft.VisualStudio.TestTools.UnitTesting;
using LodeRunnerTests.VisualTester;

namespace LodeRunner.Model.SingleComponents.Tests
{
    [TestClass]
    public class WaterTests
    {
        [TestMethod, Ignore]
        public void DrawTest()
        {
            var visualizer = new ElementVisualizaer();

            visualizer.Add(new Water(0, 0));
            visualizer.Add(new Water(20, 0));
            visualizer.Add(new Water(20, 20));

            visualizer.Start();
        }
    }
}