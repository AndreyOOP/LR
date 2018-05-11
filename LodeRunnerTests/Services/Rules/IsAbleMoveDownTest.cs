﻿namespace LodeRunnerTests.Services.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services;
    using LodeRunner.Services.Rules;
    using LodeRunner.Control;

    [TestClass]
    public class IsAbleMoveDownTests
    {
        private Controller controller;
        private Model model;
        private Player player;
        private IsAbleMoveDownRule rule;

        // Model:
        // space|player|space
        // stone|space |brick
        [TestInitialize]
        public void Setup()
        {
            model = new ModelLoadService().Load(@"TestModels\IsAbleMoveDown.lev");
            player = model.Player;
            controller = new Controller(model, new LodeRunner.View());
            rule = new IsAbleMoveDownRule(controller);
        }

        [TestMethod]
        public void IsAbleMoveDownTest()
        {
            int[] list = { 20, 60 };

            foreach(int x in list)
            {
                player.X = x;
                Assert.AreEqual(true, rule.Check(), $"Fail on player.X = {x}");
            }
        }

        [TestMethod]
        public void IsNotAbleMoveDownTest()
        {
            int[] list = { 0, 40};

            foreach (int x in list)
            {
                player.X = x;
                Assert.AreEqual(false, rule.Check(), $"Fail on player.X = {x}");
            }
        }

        [TestMethod]
        public void IsNotAbleMoveDownOutOfFieldTest()
        {
            player.Y += 20;
            Assert.IsFalse(rule.Check());
        }
    }
}