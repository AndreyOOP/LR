namespace LodeRunnerTests.Services.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services;
    using LodeRunner.Services.Rules;
    using LodeRunner.Control;

    [TestClass]
    public class IsAbleMoveLeftTest
    {
        private Controller controller;
        private Model model;
        private Player player;
        private IsAbleMoveLeftRule rule;

        // Model setup:
        // blank|player
        // stone|blank
        // stone|blank
        [TestInitialize]
        public void Setup()
        {
            model = new Model();
            model.Add(new Stone(0, 20));
            model.Add(new Stone(0, 40));
            model.Player = new Player(20, 0);


            player = model.Player;
            controller = new Controller(model, new LodeRunner.View());
            rule = new IsAbleMoveLeftRule(controller);
        }

        [TestMethod]
        public void CannotMoveLeftTest()
        {
            int[] list = { 1, 10, 20, 40, 45, 59 };

            foreach (int y in list)
            {
                player.Y = y;
                Assert.AreEqual(false, rule.Check(), $"Fail on player.Y = {y}");
            }
        }

        [TestMethod]
        public void CanMoveLeftTest()
        {
            int[] list = { 0, 60, 70 };

            foreach (int y in list)
            {
                player.Y = y;
                Assert.AreEqual(true, rule.Check(), $"Fail on player.Y = {y}");
            }
        }
    }
}
