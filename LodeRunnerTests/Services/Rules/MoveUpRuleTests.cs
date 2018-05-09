namespace LodeRunnerTests.Services.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services;
    using LodeRunner.Services.Rules;

    [TestClass()]
    public class MoveUpRuleTests
    {
        private Model model;
        private Player player;
        private MoveUpRule rule;

        // Model setup
        // stairs|blank |stairs
        // stairs|player|stairs
        [TestInitialize]
        public void Setup()
        {
            model = new ModelLoadService().Load(@"TestModels\MoveUp.lev");
            player = model.Player;
            rule = new MoveUpRule(model);
        }

        [TestMethod()]
        public void CheckTest()
        {
            Assert.IsFalse(rule.Check());
        }

        [TestMethod()]
        public void CheckTest1()
        {
            player.X = 19;

            Assert.IsTrue(rule.Check());
            Assert.AreEqual(18, player.X);
            Assert.AreEqual(20, player.Y);
        }

        [TestMethod()]
        public void CheckTest3()
        {
            player.X = 0;

            Assert.IsTrue(rule.Check());
            Assert.AreEqual(0 , player.X);
            Assert.AreEqual(19, player.Y);
        }

        [TestMethod()]
        public void CheckTest4()
        {
            player.X = 21;

            Assert.IsTrue(rule.Check());
            Assert.AreEqual(22, player.X);
            Assert.AreEqual(20, player.Y);
        }

        [TestMethod()]
        public void CheckTest5()
        {
            player.X = 40;

            Assert.IsTrue(rule.Check());
            Assert.AreEqual(40, player.X);
            Assert.AreEqual(19, player.Y);
        }

        [TestMethod()]
        public void CheckTest6()
        {
            player.X = 41;

            Assert.IsTrue(rule.Check());
            Assert.AreEqual(40, player.X);
            Assert.AreEqual(20, player.Y);
        }
    }
}