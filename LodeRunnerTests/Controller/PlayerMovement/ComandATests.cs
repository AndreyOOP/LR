namespace LodeRunnerTests.Controller.PlayerMovement
{
    using LodeRunner.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services.Command;
    using LodeRunner.Animation;
    using LodeRunnerTests;
    using System.Drawing;

    [TestClass()]
    public class ComandATests
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

        [TestMethod()]
        public void ComandAInFieldTest()
        {
            player.X = 10;
            player.Animation = null;

            new CommandA(model).Execute();

            Assert.AreEqual(9, player.X);
            Assert.AreEqual(Reflection.GetPrivateField<AnimationImage>(player, "leftAnimation"), player.Animation);
        }

        [TestMethod()]
        public void ComandAOutOfFieldTest()
        {
            player.X = 0;
            player.Animation = new AnimationImage(new Bitmap(1, 1), 1, 1);

            new CommandA(model).Execute();

            Assert.AreEqual(0, player.X);
            Assert.AreEqual(null, player.Animation);
        }
    }
}