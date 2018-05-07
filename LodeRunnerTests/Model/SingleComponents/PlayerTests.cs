using Microsoft.VisualStudio.TestTools.UnitTesting;
using LodeRunnerTests.VisualTester;
using System.Timers;

namespace LodeRunner.Model.SingleComponents.Tests
{
    [TestClass]
    public class PlayerTests
    {
        private Player player;
        private Timer timer;

        [TestMethod]
        public void DrawTest() // todo refactor
        {
            timer = new Timer() {
                Interval = 70,
                Enabled = true,
            };
            timer.Elapsed += eh;

            player = new Player() { X = 40, Y = 40 };
            var visualizer = new ElementVisualizaer();

            visualizer.Add(player);

            visualizer.Start();
        }

        private void eh(object sender, ElapsedEventArgs e)
        {
            player.X += 1;
        }
    }
}