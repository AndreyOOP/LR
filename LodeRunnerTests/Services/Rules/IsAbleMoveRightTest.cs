namespace LodeRunnerTests.Services.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services;
    using LodeRunner.Services.Rules;

    [TestClass]
    public class IsAbleMoveRightTest
    {
        private Model model;
        private Player player;
        private IsAbleMoveRightRule rule;

        // Model setup:
        // player|blank
        // blank |brick
        // blank |brick
        [TestInitialize]
        public void Setup()
        {
            model = new ModelLoadService().Load(@"TestModels\IsPossibleMoveRight.lev");
            player = model.Player;
            rule = new IsAbleMoveRightRule(model);
        }

        [TestMethod]
        public void PossibleMoveRightTest()
        {
            int[] list = { 0, 60, 61 };

            foreach (int y in list)
            {
                player.Y = y;
                Assert.AreEqual(true, rule.Check(), $"Fail on player.Y = {y}");
            }
        }

        [TestMethod]
        public void NotPossibleMoveRightTest()
        {
            int[] list = { 1, 10, 19, 20, 30, 59 };

            foreach (int y in list)
            {
                player.Y = y;
                Assert.AreEqual(false, rule.Check(), $"Fail on player.Y = {y}");
            }
        }
    }
}
