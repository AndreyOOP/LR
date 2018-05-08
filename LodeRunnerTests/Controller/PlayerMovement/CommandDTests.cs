namespace LodeRunnerTests.Controller.PlayerMovement
{
    using LodeRunner.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services.Command;
    using LodeRunner;
    using LodeRunner.Animation;
    using System.Drawing;

    [TestClass]
    public class CommandDTests
    {
        private Player player;
        private Model model;

        [TestInitialize]
        public void TestSetup()
        {
            model = new Model();
            model.Add(ComponentType.Player, new Player(0, 0));
            player = model.Get<Player>(ComponentType.Player);
        }

        [TestMethod]
        public void ComandDInFieldTest()
        {
            player.X = 10;
            player.Animation = null;

            new CommandD(model).Execute();

            Assert.AreEqual(11, player.X);
            Assert.AreEqual(Reflection.GetPrivateField<AnimationImage>(player, "rightAnimation"), player.Animation);
        }

        [TestMethod]
        public void ComandDOutOfFieldTest()
        {
            player.X = Const.WindowXSize - Const.BlockSize;
            player.Animation = new AnimationImage(new Bitmap(1, 1), 1, 1);

            new CommandD(model).Execute();

            Assert.AreEqual(Const.WindowXSize - Const.BlockSize, player.X);
            Assert.AreEqual(null, player.Animation);
        }
    }
}
