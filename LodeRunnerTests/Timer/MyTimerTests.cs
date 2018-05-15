using System.Diagnostics;
using System.Timers;
using LodeRunner.Services.Timer;
using LodeRunnerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class MyTimerTests
{
    private MyTimer timer;

    [TestMethod]
    public void InitialState()
    {
        State.GetState(new MyTimer(100));

        Assert.AreEqual(100, State.TimerInterval);
        Assert.AreEqual(0, State.ResumeInterval);
        Assert.IsNull(State.Handler);
    }

    [TestMethod]
    public void Start()
    {
        timer = new MyTimer(100);
        timer.Start();

        State.GetState(timer);
        
        Assert.IsTrue(State.IsTimerEnabled);
        Assert.IsTrue(State.IsStopWatchEnabled);
        Assert.AreEqual(0, State.ResumeInterval);
        Assert.AreEqual(100, State.TimerInterval);
    }

    [TestMethod]
    public void Stop()
    {
        int[] tests    = new int[] { 0  , 10, 50, 100, 120, 240 };
        int[] expected = new int[] { 100, 90, 50, 0  , 80 , 60 };

        for (int i=0; i<tests.Length; i++)
        {
            timer = new MyTimer(100);
            timer.Start();
            System.Threading.Thread.Sleep(tests[i]);
            timer.Stop();

            State.GetState(timer);

            Assert.IsFalse(State.IsTimerEnabled);
            Assert.IsFalse(State.IsStopWatchEnabled);
            Assert.IsTrue(State.TimerInterval == 100);
            Assert.IsTrue(State.ResumeInterval >= expected[i]-1 || State.ResumeInterval <= expected[i] + 1);
        }
    }

    [TestMethod]
    public void Resume()
    {
        int[] tests = new int[] { 0, 10, 50, 100, 432, 500};

        for(int i=0; i<tests.Length; i++)
        {
            timer = new MyTimer(100);
            timer.Start();
            System.Threading.Thread.Sleep(230);
            timer.Stop();
            System.Threading.Thread.Sleep(tests[i]);
            timer.Resume();

            State.GetState(timer);

            Assert.IsTrue(State.TimerInterval >= 69 && State.TimerInterval <= 71);
            Assert.IsTrue(State.ResumeInterval >= 69 && State.ResumeInterval <= 71);
        }
    }

    [TestMethod]
    public void SetEventHandler()
    {
        ElapsedEventHandler handler = Handler;
        timer = new MyTimer(10);
        timer.SetEventHandler(Handler);

        State.GetState(timer);

        Assert.AreEqual(Handler, State.Handler);
    }

    [TestMethod]
    public void Deserialization()
    {
        var timer = new MyTimer(123);
        timer.SetEventHandler(Handler);
        timer.Start();
        var serialized   = Reflection.SerializeToMemory(timer);
        var deserialized = Reflection.DeserializeFromMemory<MyTimer>(serialized);

        State.GetState(deserialized);

        Assert.AreEqual(123, State.TimerInterval);
        Assert.AreEqual(Handler, State.Handler);
        Assert.IsFalse(State.IsTimerEnabled);
        Assert.IsFalse(State.IsStopWatchEnabled);
    }

    public static void Handler(object sender, ElapsedEventArgs e)
    {
    }

    private class State
    {
        public static bool IsTimerEnabled;
        public static bool IsStopWatchEnabled;
        public static int ResumeInterval;
        public static int TimerInterval;
        public static ElapsedEventHandler Handler;

        public static void GetState(MyTimer timer)
        {
            IsTimerEnabled     = Reflection.GetPrivateField<Timer>(timer, "timer").Enabled;
            IsStopWatchEnabled = Reflection.GetPrivateField<Stopwatch>(timer, "stopwatch").IsRunning;
            ResumeInterval     = Reflection.GetPrivateField<int>(timer, "resumeInt");
            TimerInterval      = (int)Reflection.GetPrivateField<Timer>(timer, "timer").Interval;
            Handler            = Reflection.GetPrivateField<ElapsedEventHandler>(timer, "handler");
        }
    }
}
