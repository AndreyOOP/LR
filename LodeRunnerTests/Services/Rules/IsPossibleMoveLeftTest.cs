﻿namespace LodeRunnerTests.Services.Rules
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services;
    using LodeRunner.Services.Rules;

    [TestClass]
    public class IsPossibleMoveLeftTest
    {
        private Model model;
        private Player player;
        private IsPossibleMoveLeftRule rule;

        // Model setup:
        // blank|player
        // stone|blank
        // stone|blank
        [TestInitialize]
        public void Setup()
        {
            model = new ModelLoadService().Load(@"TestModels\IsPossibleMoveLeft.lev");
            player = model.Player;
            rule = new IsPossibleMoveLeftRule(model);
        }

        [TestMethod]
        public void CannotMoveLeftTest()
        {
            int[] list = { 1, 10, 20, 40, 45, 59 };

            foreach (int y in list)
            {
                player.Y = y;
                Assert.AreEqual(false, rule.Check(), $"Fail on player.Y = {y}");
            }
        }

        [TestMethod]
        public void CanMoveLeftTest()
        {
            int[] list = { 0, 60, 70 };

            foreach (int y in list)
            {
                player.Y = y;
                Assert.AreEqual(true, rule.Check(), $"Fail on player.Y = {y}");
            }
        }
    }
}
