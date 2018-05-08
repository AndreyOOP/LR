﻿namespace LodeRunnerTests.Controller.PlayerMovement
{
    using LodeRunner.Model;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LodeRunner.Model.SingleComponents;
    using LodeRunner.Services.Command;
    using LodeRunner;
    using LodeRunner.Animation;
    using System.Drawing;
    using LodeRunner.Model.ModelComponents;

    [TestClass]
    public class CommandDTests
    {
        private Player player;
        private Model model;

        [TestInitialize]
        public void TestSetup()
        {
            var bricks = new ComponentsCollection<Brick>();
            bricks.Add(new Brick(Const.WindowXSize - Const.BlockSize, 20));

            model = new Model();
            model.Add(ComponentType.Player, new Player(0, 0));
            model.Add(ComponentType.Brick, bricks);
            model.Add(ComponentType.Stone, new ComponentsCollection<Stone>());
            model.Add(ComponentType.Stairs, new ComponentsCollection<Stairs>());
            player = model.Get<Player>(ComponentType.Player);
        }

        [TestMethod]
        public void ComandDInFieldTest()
        {
            player.X = Const.WindowXSize - Const.BlockSize - 5;
            player.Animation = null;

            new CommandD(model).Execute();

            Assert.AreEqual(426, player.X);
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
