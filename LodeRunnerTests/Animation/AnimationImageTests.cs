using System;
using System.Drawing;
using LodeRunner.Animation;
using LodeRunnerTests;
using LodeRunnerTests.Animation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LodeRunnerTests.Animation.TimerMock;

[TestClass]
public class AnimationImageTests
{
    private TimerMock timer;
    private string path = @"Animation\AnimatedTestImage.png";
    private int frameLength = 30;
    private int frameQty = 5;
    private Animation animation;

    [TestInitialize]
    public void Initialize()
    {
        timer = new TimerMock();
        animation = new Animation(path, frameLength, timer);
    }

    [TestMethod]
    public void AnimationInitialization()
    {
        State.GetState(animation);

        Assert.AreEqual(MockTimerState.Stop, State.Timer.State);
        Assert.AreEqual(0, State.CurrentFrame);
        Assert.AreEqual(5, State.Frames.Length);
    }

    [TestMethod]
    public void IncorrectFrameLengthTest()
    {
        try
        {
            new Animation(path, 0, new TimerMock());
            Assert.Fail("No argument exception thrown");
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
            new Animation(path, frameLength + 1, new TimerMock());
            Assert.Fail("No argument exception thrown");
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("Width of animationImage has to be longer than frameLength", ex.Message);
        }
    }

    [TestMethod]
    public void Start()
    {
        animation.Start();
        State.GetState(animation);

        Assert.AreEqual(MockTimerState.Start, State.Timer.State);
        Assert.AreEqual(0, State.CurrentFrame);
    }

    [TestMethod]
    public void Pause()
    {
        animation.Pause();
        State.GetState(animation);

        Assert.AreEqual(MockTimerState.Stop, State.Timer.State);
    }

    [TestMethod]
    public void Continue()
    {
        animation.Continue();
        State.GetState(animation);

        Assert.AreEqual(MockTimerState.Resumed, State.Timer.State);
    }

    [TestMethod]
    public void AnimationFramesSequence()
    {
        for (int i = 1; i < 5 * frameQty; i++)
        {
            timer.NextTick();
            State.GetState(animation);

            Assert.AreEqual(i % frameQty, State.CurrentFrame);
        }
    }

    [TestMethod]
    public void AnimationComplete()
    {
        int counter = 0;
        animation.AnimationComplete += (sender, e) => counter++;

        for (int i = 0; i < 5 * frameQty; i++)
        {
            timer.NextTick();
        }

        Assert.AreEqual(5, counter);
    }

    private class State
    {
        public static TimerMock Timer { get; set; }
        public static int CurrentFrame { get; set; }
        public static Bitmap[] Frames { get; set; }

        public static void GetState(Animation animation)
        {
            Timer = Reflection.GetPrivateField<TimerMock>(animation, "myTimer");
            CurrentFrame = Reflection.GetPrivateField<int>(animation, "currentFrame");
            Frames = Reflection.GetPrivateField<Bitmap[]>(animation, "frames");
        }
    }
}