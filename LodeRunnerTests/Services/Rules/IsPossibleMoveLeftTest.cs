namespace LodeRunnerTests.Services.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services;
    using LodeRunner.Services.Rules;

    [TestClass]
    public class IsPossibleMoveLeftTest
    {
        private Model model;
        private Player player;
        private IsPossibleMoveLeftRule rule;

        // Model setup:
        // blank|player
        // stone|blank
        // stone|blank
        [TestInitialize]
        public void Setup()
        {
            ModelLoadService mls = new ModelLoadService();
            model = mls.Load(@"TestModels\IsPossibleMoveLeft.lev");
            player = model.Get<Player>(ComponentType.Player);
            rule = new IsPossibleMoveLeftRule(model);
        }

        [TestMethod]
        public void CannotMoveLeftTest()
        {
            int[] YPosCannotMove = { 1, 10, 20, 40, 45, 59 };

            foreach(int y in YPosCannotMove)
            {
                player.Y = y;
                Assert.IsFalse(rule.Check());
            }
        }

        [TestMethod]
        public void CanMoveLeftTest()
        {
            int[] YPosCanMove = { 0, 60, 70 };

            foreach (int y in YPosCanMove)
            {
                player.Y = y;
                Assert.IsTrue(rule.Check());
            }
        }

        [TestMethod]
        public void TestMethod2()
        {
            player.X -= 10;
            Assert.IsTrue(rule.Check());
        }

        [TestMethod]
        public void TestMethod3()
        {
            player.X -= 20;
            Assert.IsFalse(rule.Check());
        }
    }
}
