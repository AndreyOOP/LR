namespace LodeRunnerTests.Services.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services;
    using LodeRunner.Services.Rules;
    using LodeRunner.Control;

    [TestClass]
    public class IsAbleMoveUpTests
    {
        private Controller controller;
        private Model model;
        private Player player;
        private IsAbleMoveUp rule;

        // Model:
        // brick|space |stone
        // space|player|space
        [TestInitialize]
        public void Setup()
        {
            model = new Model();
            model.Add(new Brick(0, 0));
            model.Add(new Stone(40, 0));
            model.Player = new Player(20, 20);

            player = model.Player;
            controller = new Controller(model, new LodeRunner.View());
            rule = new IsAbleMoveUp(controller);
        }

        [TestMethod]
        public void IsAbleMoveUpTest()
        {
            int[] list = { 20, 60 };

            foreach(int x in list)
            {
                player.X = x;
                Assert.AreEqual(true, rule.Check(), $"Fail on player.X = {x}");
            }
        }

        [TestMethod]
        public void IsNotAbleMoveUpTest()
        {
            int[] list = { 0, 40 };

            foreach (int x in list)
            {
                player.X = x;
                Assert.AreEqual(false, rule.Check(), $"Fail on player.X = {x}");
            }
        }

        [TestMethod]
        public void IsNotAbleMoveUpOutOfFieldTest()
        {
            player.Y = 0;
            Assert.IsFalse(rule.Check());
        }
    }
}