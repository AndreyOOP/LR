using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LodeRunner.Services.Rules.Tests
{
    using LodeRunner.Model;
    using LodeRunner.Model.ModelComponents;
    using LodeRunner.Model.SingleComponents;

    [TestClass()]
    public class IsFallRuleTests
    {
        private Player player;
        private IsFallRule isFallRule;

        [TestInitialize]
        public void Setup()
        {
            var stairs = new ComponentsCollection<Stairs>();
            var bricks = new ComponentsCollection<Brick>();
            var stones = new ComponentsCollection<Stone>();
            bricks.Add(new Brick(40, 40));
            bricks.Add(new Brick(60, 40));

            player = new Player(0, 20);

            var model = new Model();
            model.Add(ComponentType.Brick, bricks);
            model.Add(ComponentType.Player, player);
            model.Add(ComponentType.Stairs, stairs);
            model.Add(ComponentType.Stone, stones);

            isFallRule = new IsFallRule(model);
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
    }
}