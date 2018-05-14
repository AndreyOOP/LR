namespace LodeRunnerTests.Services.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services;
    using LodeRunner.Services.Rules;
    using static LodeRunner.Services.Intersection;
    using LodeRunner.Control;
    using LodeRunner;

    [TestClass()]
    public class MoveUpRuleTests
    {
        private Controller controller;
        private Model model;
        private Player player;
        private MoveUpRule rule;

        // Model setup
        // stairs|blank |stairs
        // stairs|player|stairs
        [TestInitialize]
        public void Setup()
        {
            model = new Model();

            model.Add(new Stairs(0, 0, Textures.Stairs));
            model.Add(new Stairs(40, 0, Textures.Stairs));
            model.Add(new Stairs(0, 20, Textures.Stairs));
            model.Add(new Stairs(40, 20, Textures.Stairs));
            model.Player = new Player(20, 20);

            player = model.Player;
            controller = new Controller(model, new LodeRunner.View());
            rule = new MoveUpRule(controller);
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
            player.Direction = Direction.Left;

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
            player.Direction = Direction.Right;

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
            player.Direction = Direction.Left;

            Assert.IsTrue(rule.Check());
            Assert.AreEqual(40, player.X);
            Assert.AreEqual(20, player.Y);
        }
    }
}