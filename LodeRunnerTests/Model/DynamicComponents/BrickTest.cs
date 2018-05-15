namespace LodeRunnerTests.Model.DynamicComponents
{
    using LodeRunner.Animation;
    using LodeRunner;
    using LodeRunner.Model.SingleComponents;
    using LodeRunnerTests.Animation;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Drawing;

    [TestClass]
    public class BrickTest
    {
        private string animationPath = @"Animation\AnimatedTestImage.png";
        private int frameWidth = 30;
        private int frameQty = 5;
        private TimerMock brickTimer;
        private TimerMock burnTimer;
        private TimerMock growTimer;
        private Animation burn;
        private Animation grow;
        private Brick brick;

        [TestInitialize]
        public void SetupTestBrick()
        {
            brickTimer = new TimerMock();
            burnTimer = new TimerMock();
            growTimer = new TimerMock();

            brick = new Brick(0, 0, brickTimer);

            grow = new Animation(animationPath, frameWidth, growTimer);
            grow.AnimationComplete += brick.OnGrowAnimationFinished;

            burn = new Animation(animationPath, frameWidth, burnTimer);
            burn.AnimationComplete += brick.OnBurnAnimationFinished;

            brick.AddDynamicState(BrickState.Burn, burn);
            brick.AddDynamicState(BrickState.Grow, grow);
            brick.AddStaticState(BrickState.Visible, Textures.Brick);
            brick.AddStaticState(BrickState.NotVisible, new Bitmap(1, 1));
        }

        [TestMethod]
        public void FromBurnToNotVisible()
        {
            brick.State = BrickState.Burn;
            brick.Burn();
            burnTimer.NextTick(frameQty);

            Assert.AreEqual(BrickState.NotVisible, brick.State);
        }

        [TestMethod]
        public void FromNotVisibleToGrow()
        {
            brick.State = BrickState.NotVisible;
            brickTimer.NextTick();

            Assert.AreEqual(BrickState.Grow, brick.State);
        }

        [TestMethod]
        public void FromGrowToVisible()
        {
            brick.State = BrickState.Grow;
            growTimer.NextTick(frameQty);

            Assert.AreEqual(BrickState.Visible, brick.State);
        }
    }
}
