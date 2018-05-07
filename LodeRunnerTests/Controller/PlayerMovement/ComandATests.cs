namespace LodeRunner.Controller.PlayerMovement
{
    using LodeRunner.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services.Command;

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

            new CommandA(model).Execute();

            Assert.AreEqual(9, player.X);
        }

        [TestMethod()]
        public void ComandAOutOfFieldTest()
        {
            player.X = 0;

            new CommandA(model).Execute();

            Assert.AreEqual(0, player.X);
        }
    }
}