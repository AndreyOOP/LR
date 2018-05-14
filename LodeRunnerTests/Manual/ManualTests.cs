using LodeRunner;
using LodeRunner.Animation;
using LodeRunner.Model.SingleComponents;
using LodeRunner.Services.Timer;
using LodeRunnerTests.Animation;
using LodeRunnerTests.VisualTester;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass, Ignore]
//[TestClass]
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

    [TestMethod]
    public void StoneDisplay()
    {
        var visualizer = new ElementVisualizaer();

        visualizer.Add(new Stone(0, 0, Textures.Stone));
        visualizer.Start();
    }
}

