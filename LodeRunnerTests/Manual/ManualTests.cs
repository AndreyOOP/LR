using System;
using LodeRunner.Animation;
using LodeRunner.Services.Timer;
using LodeRunnerTests.Animation;
using LodeRunnerTests.VisualTester;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass, Ignore]
public class ManualTests
{
    [TestMethod]
    public void ManualAnimationDisplayTest()
    {
        string path = @"Animation\AnimatedTestImage.png";
        var visualizer = new ElementVisualizaer();

        var animation1 = new Animation(path, 30, new MyTimer(50));
        var animation2 = new Animation(path, 30, new MyTimer(150));

        animation1.Start();
        animation2.Start();

        visualizer.Add(new TestAnimationElement() { Animation = animation1, X = 0, Y = 0 });
        visualizer.Add(new TestAnimationElement() { Animation = animation2, X = 30, Y = 0 });

        visualizer.Start();
    }
}

