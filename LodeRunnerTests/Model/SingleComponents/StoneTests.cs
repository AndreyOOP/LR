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

            visualizer.Add(new Stone() { X = 0,  Y = 0 });
            visualizer.Add(new Stone() { X = 20, Y = 0 });
            visualizer.Add(new Stone() { X = 20, Y = 20 });

            visualizer.Start();
        }
    }
}