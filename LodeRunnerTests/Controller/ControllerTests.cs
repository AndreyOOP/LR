namespace LodeRunner.Control.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;

    [TestClass]
    public class ControllerTests
    {
        Player player = new Player(10, 0);
        Model model = new Model();
        View view = new View();
        Controller controller;
        

        [TestInitialize]
        public void Setup()
        {
            model.Player = player;
            model.Add(new Brick(0, 20));

            controller = new Controller(model, view);
        }

        [TestMethod()]
        public void OnKeyInputTest()
        {
            //Assert.AreEqual(10, player.X);

            //controller.commands.SetUserInput('d');
            //controller.commands.GetActiveCommand().Execute();

            //Assert.AreEqual(11, player.X);
        }
    }
}