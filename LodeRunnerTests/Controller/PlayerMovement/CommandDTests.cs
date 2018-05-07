namespace LodeRunnerTests.Controller.PlayerMovement
{
    using LodeRunner.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services.Command;
    using LodeRunner;

    [TestClass]
    public class CommandDTests
    {
        private Player player;
        private Model model;

        [TestInitialize]
        public void TestSetup()
        {
            model = new Model();
            model.Add(ComponentType.Player, new Player());
            player = model.Get<Player>(ComponentType.Player);
        }

        [TestMethod]
        public void ComandDInFieldTest()
        {
            player.X = 10;

            new CommandD(model).Execute();

            Assert.AreEqual(11, player.X);
        }

        [TestMethod]
        public void ComandDOutOfFieldTest()
        {
            player.X = Const.WindowXSize - Const.BlockSize;

            new CommandD(model).Execute();

            Assert.AreEqual(Const.WindowXSize - Const.BlockSize, player.X);
        }
    }
}
