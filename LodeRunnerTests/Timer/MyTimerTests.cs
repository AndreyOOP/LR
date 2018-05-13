using System;
using System.Diagnostics;
using System.Timers;
using LodeRunner;
using LodeRunner.Animation;
using LodeRunner.Services.Timer;
using LodeRunnerTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass, Serializable]
public class MyTimerTests
{
    private MyTimer timer;

    [TestInitialize]
    public void Setup()
    {
        timer = new MyTimer(100);
    }

    [TestMethod]
    public void InitialState()
    {
        Assert.AreEqual(100, Reflection.GetPrivateField<int>(timer, "interval"));
        Assert.AreEqual(null, Reflection.GetPrivateField<Timer>(timer, "handler"));
    }

    [TestMethod]
    public void Start()
    {
        timer.Start();
        Assert.IsTrue(Reflection.GetPrivateField<Timer>(timer, "timer").Enabled);
        Assert.AreEqual(0, Reflection.GetPrivateField<Stopwatch>(timer, "stopwatch").ElapsedMilliseconds);
    }

    [TestMethod]
    public void Stop()
    {
        timer.Start();
        System.Threading.Thread.Sleep(240);
        timer.Stop();

        Assert.IsFalse(Reflection.GetPrivateField<Timer>(timer, "timer").Enabled);
        Assert.IsTrue(60 == Reflection.GetPrivateField<int>(timer, "resumeInt") || 61 == Reflection.GetPrivateField<int>(timer, "resumeInt"));
    }

    // todo temoporary solution
    [TestMethod]
    public void Resume()
    {
        timer = new MyTimer(1000);
        timer.Start();
        System.Threading.Thread.Sleep(2300);

        timer.Stop();
        System.Threading.Thread.Sleep(100);
        timer.Resume();
        Assert.IsTrue(700 == Reflection.GetPrivateField<Timer>(timer, "timer").Interval || 701 == Reflection.GetPrivateField<Timer>(timer, "timer").Interval);

        timer.Start();
        Assert.AreEqual(1000, Reflection.GetPrivateField<Timer>(timer, "timer").Interval);
    }

    [TestMethod] //tests after serializations...
    public void SetEventHandler()
    {
        ElapsedEventHandler handler = Handler;
        timer.SetEventHandler(Handler);

        Assert.AreEqual(Handler, Reflection.GetPrivateField<ElapsedEventHandler>(timer, "handler"));
    }

    [TestMethod]
    public void Deserialization()
    {
        var timer = new MyTimer(123);
        timer.SetEventHandler(Handler);
        timer.Start();

        var serialized   = Reflection.SerializeToMemory(timer);
        var deserialized = Reflection.DeserializeFromMemory<MyTimer>(serialized);
        
        Assert.AreEqual(123, Reflection.GetPrivateField<int>(deserialized, "interval"));
        Assert.AreEqual(Handler,Reflection.GetPrivateField<ElapsedEventHandler>(deserialized, "handler"));
        Assert.IsFalse(Reflection.GetPrivateField<Timer>(deserialized, "timer").Enabled);
    }

    public static void Handler(object sender, ElapsedEventArgs e)
    {
    }
}
