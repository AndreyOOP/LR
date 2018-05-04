namespace LodeRunner.Control.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;

    [TestClass()]
    public class ControllerTests
    {
        Player player = new Player() { X = 10, Y = 0};
        Model model = new Model();
        Controller controller = new Controller();
        View view = new View();

        [TestInitialize]
        public void Setup()
        {
            model.Add(ComponentType.Player, player);

            controller.Model = model;
            controller.View = view;
        }

        [TestMethod()]
        public void OnKeyInputTest()
        {
            Assert.AreEqual(10, player.X);

            controller.OnKeyInput();

            Assert.AreEqual(15, player.X);
        }
    }
}