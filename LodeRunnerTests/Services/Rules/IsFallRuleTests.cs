using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LodeRunner.Services.Rules.Tests
{
    using LodeRunner.Model.SingleComponents;
    using LodeRunnerTests.TestModels;

    [TestClass()]
    public class IsFallRuleTests
    {
        private TestModelFactory testModelFactory = new TestModelFactory();
        private Player player;
        private IsFallRule isFallRule;

        [TestInitialize]
        public void Setup()
        {
            testModelFactory.SetFallRuleTestModel();
            player = testModelFactory.Player;

            isFallRule = new IsFallRule(testModelFactory.Model);
        }

        [TestMethod()]
        public void LeftOutTest()
        {
            player.X = 10;

            isFallRule.Check();

            Assert.AreEqual(21, player.Y);
        }

        [TestMethod()]
        public void LeftHalfOutTest()
        {
            player.X = 25;

            isFallRule.Check();

            Assert.AreEqual(20, player.Y);
        }

        [TestMethod()]
        public void AboveTest()
        {
            player.X = 45;

            isFallRule.Check();

            Assert.AreEqual(20, player.Y);
        }

        [TestMethod()]
        public void RightOutTest()
        {
            player.X = 79;

            isFallRule.Check();

            Assert.AreEqual(20, player.Y);
        }

        [TestMethod()]
        public void OutTest()
        {
            player.X = 80;

            isFallRule.Check();

            Assert.AreEqual(21, player.Y);
        }

        [TestMethod()]
        public void OutYTest()
        {
            player.X = 79;
            player.Y = 19;

            isFallRule.Check();

            Assert.AreEqual(20, player.Y);
        }

        //Model default setup:
        // space|player|space
        // brick|space |brick

        [TestMethod]
        public void MyTestMethod()
        {
            testModelFactory.SetFallRuleTestModel1();

            isFallRule = new IsFallRule(testModelFactory.Model);

            Assert.IsFalse(isFallRule.Check());
        }

        [TestMethod]
        public void MyTestMethod2()
        {
            testModelFactory.SetFallRuleTestModel1();
            testModelFactory.Player.X += 30;

            isFallRule = new IsFallRule(testModelFactory.Model);

            Assert.IsTrue(isFallRule.Check());
        }
    }
}