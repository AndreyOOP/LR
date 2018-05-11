namespace LodeRunnerTests.Services.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Model;
    using LodeRunner.Services.Rules;
    using LodeRunner.Services;
    using LodeRunner.Control;

    [TestClass()]
    public class IsFallRuleTests
    {
        private Controller controller;
        private Model model;
        private Player player;
        private IsNotFallRule rule;

        // Model default setup:
        // space|player|space
        // brick|space |brick
        [TestInitialize]
        public void Setup()
        {
            model = new ModelLoadService().Load(@"TestModels\FallBetweenBricks.lev");
            player = model.Player;
            controller = new Controller(model, new LodeRunner.View());
            rule = new IsNotFallRule(controller);
        }

        [TestMethod]
        public void IsNotFallTest()
        {
            int[] list = {0, 19, 21, 40, 59};

            foreach(int x in list)
            {
                player.X = x;
                Assert.AreEqual(true, rule.Check(), $"Fail on player.X = {x}");
            }
        }

        [TestMethod]
        public void IsFallTest()
        {
            int[] list = {20, 60};

            foreach (int x in list)
            {
                player.X = x;
                Assert.AreEqual(false, rule.Check(), $"Fail on player.X = {x}");
            }
        }
    }
}