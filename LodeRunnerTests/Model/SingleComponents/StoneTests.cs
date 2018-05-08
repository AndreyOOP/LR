using Microsoft.VisualStudio.TestTools.UnitTesting;
using LodeRunnerTests.VisualTester;

namespace LodeRunner.Model.SingleComponents.Tests
{
    [TestClass]
    public class StoneTests
    {
        [TestMethod, Ignore]
        public void DrawTest()
        {
            var visualizer = new ElementVisualizaer();

            visualizer.Add(new Stone(0, 0));
            visualizer.Add(new Stone(20, 0));
            visualizer.Add(new Stone(20, 20));

            visualizer.Start();
        }
    }
}