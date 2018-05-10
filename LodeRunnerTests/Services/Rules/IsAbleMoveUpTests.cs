namespace LodeRunnerTests.Services.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services;
    using LodeRunner.Services.Rules;

    [TestClass]
    public class IsAbleMoveUpTests
    {
        private Model model;
        private Player player;
        private IsAbleMoveUp rule;

        // Model:
        // brick|space |stone
        // space|player|space
        [TestInitialize]
        public void Setup()
        {
            model = new ModelLoadService().Load(@"TestModels\IsAbleMoveUp.lev");
            player = model.Player;
            rule = new IsAbleMoveUp(model);
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