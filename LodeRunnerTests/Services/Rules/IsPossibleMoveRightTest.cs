namespace LodeRunnerTests.Services.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services;
    using LodeRunner.Services.Rules;

    [TestClass]
    public class IsPossibleMoveRightTest
    {
        private Model model;
        private Player player;
        private IsPossibleMoveRightRule rule;

        // Model setup:
        // player|blank
        // blank |brick
        // blank |brick
        [TestInitialize]
        public void Setup()
        {
            ModelLoadService mls = new ModelLoadService();
            model = mls.Load(@"TestModels\IsPossibleMoveRight.lev");
            player = model.Get<Player>(ComponentType.Player);
            rule = new IsPossibleMoveRightRule(model);
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(rule.Check());
        }

        [TestMethod]
        public void TestMethod2()
        {
            player.Y += 10;

            Assert.IsFalse(rule.Check());
        }

        [TestMethod]
        public void TestMethod3()
        {
            player.Y += 40;

            Assert.IsFalse(rule.Check());
        }

        [TestMethod]
        public void TestMethod4()
        {
            player.Y += 59;

            Assert.IsFalse(rule.Check());
        }

        [TestMethod]
        public void TestMethod5()
        {
            player.Y += 60;

            Assert.IsTrue(rule.Check());
        }
    }
}
