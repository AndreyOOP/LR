using System;
using System.Drawing;
using AnimationTests;
using LodeRunner;
using LodeRunner.Animation;
using LodeRunner.Services.Timer;
using LodeRunnerTests;
using LodeRunnerTests.Animation;
using LodeRunnerTests.VisualTester;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LodeRunnerTests.Animation.TimerMock;

[TestClass]
public class AnimationImageTests
{
    private int x;
    private AnimationImageTestClass animation;

    [TestInitialize]
    public void Initialize()
    {
        animation = new AnimationImageTestClass(Const.BrickTexture, 2, new MyTimer(1));
    }

    [TestMethod]
    public void MyTestMethodMockTimer()
    {
        var timer = new TimerMock(100);
        Animation animation = new Animation(Const.PlayerFallAnimation, Const.BlockSize, timer);

        for(int i=0; i<10; i++)
        {
            Assert.AreEqual(i%4, Reflection.GetPrivateField<int>(animation, "currentFrame"));
            timer.NextFrame();
        }
    }

    [TestMethod]
    public void Start()
    {
        var timer = new TimerMock(100);
        Animation animation = new Animation(Const.PlayerFallAnimation, Const.BlockSize, timer);
        animation.Start();

        var myTimer = Reflection.GetPrivateField<TimerMock>(animation, "myTimer");
        Assert.AreEqual(MockTimerState.Start, myTimer.State);
    }

    [TestMethod]
    public void MyTestMethodMockTimerOnFinish()
    {
        var timer = new TimerMock(100);
        Animation animation = new Animation(Const.PlayerFallAnimation, Const.BlockSize, timer);
        animation.AnimationComplete += Animation_AnimationComplete;

        x = 0;

        for (int i = 0; i < 12; i++)  // called each time all frames are completed
        {
            timer.NextFrame();
        }

        Assert.AreEqual(3, x);
    }

    private void Animation_AnimationComplete(object sender, EventArgs e)
    {
        x++;
    }

    [TestMethod]
    public void FramesAnimation()
    {
        Animation animation = new Animation(Const.PlayerFallAnimation, Const.BlockSize, new MyTimer(100));
        animation.Start();

        System.Threading.Thread.Sleep(1);

        string actualFrames = "";

        for (int i = 0; i < 9; i++)
        {
            actualFrames += Reflection.GetPrivateField<int>(animation, "currentFrame");
            System.Threading.Thread.Sleep(100);
        }

        Assert.AreEqual("001230123", actualFrames);
    }

    [TestMethod]
    public void Pause()
    {
        Animation animation = new Animation(Const.PlayerFallAnimation, Const.BlockSize, new MyTimer(100));

        animation.Start();
        System.Threading.Thread.Sleep(1);
        animation.Pause();
        System.Threading.Thread.Sleep(260);
        animation.Continue();

        string actualFrames = "";
        for (int i = 0; i < 9; i++)
        {
            actualFrames += Reflection.GetPrivateField<int>(animation, "currentFrame");
            System.Threading.Thread.Sleep(100);
        }

        Assert.AreEqual("001230123", actualFrames);
    }

    [TestMethod]
    public void ResetTest()
    {
        AnimateTillFrame(5);
        animation.Continue();
        Assert.AreEqual(5, animation.CurrentFrame);
    }

    [TestMethod]
    public void CurrentFrameTest()
    {
        AnimateTillFrame(0);
        Assert.AreEqual(0, animation.CurrentFrame);

        AnimateTillFrame(5);
        Assert.AreEqual(5, animation.CurrentFrame);

        AnimateTillFrame(10);
        Assert.AreEqual(0, animation.CurrentFrame);

        AnimateTillFrame(14);
        Assert.AreEqual(4, animation.CurrentFrame);
    }

    [TestMethod, Ignore]
    public void ManualAnimationDisplayTest()
    {
        ElementVisualizaer visualizer = new ElementVisualizaer();

        var animatedBitmap = @"Animation\Files\AnimatedTestImage.png";
        var animation1 = new Animation(animatedBitmap, 30, new MyTimer(50));
        var animation2 = new Animation(animatedBitmap, 30, new MyTimer(50));

        animation1.Start();
        animation2.Start();

        visualizer.Add(new TestAnimationElement() { Animation = animation1, X = 0, Y = 0 });
        visualizer.Add(new TestAnimationElement() { Animation = animation2, X = 30, Y = 0 });

        visualizer.Start();
    }

    [TestMethod]
    public void IncorrectFrameLengthTest()
    {
        try
        {
            new AnimationImageTestClass(Const.BrickTexture, 0, new MyTimer(1));
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("frameLength has to be >= 1", ex.Message);
        }
    }

    [TestMethod]
    public void IncorrectImageToFrameLengthRatioTest()
    {
        try
        {
            new AnimationImageTestClass(Const.BrickTexture, 15, new MyTimer(1));
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual($"Width of animationImage has to be longer than frameLength", ex.Message);
        }
    }

    private void AnimateTillFrame(int qty)
    {
        animation.Start();

        while (animation.TicksCounter != qty)
        {
        }

        animation.Pause();
    }
}