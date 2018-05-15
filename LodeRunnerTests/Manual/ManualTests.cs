using LodeRunner;
using LodeRunner.Animation;
using LodeRunner.Model;
using LodeRunner.Model.DynamicComponents;
using LodeRunner.Model.SingleComponents;
using LodeRunner.Services.Timer;
using LodeRunnerTests.Animation;
using LodeRunnerTests.VisualTester;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Timers;

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
    public void StaticComponentsDisplay()
    {
        var visualizer = new ElementVisualizaer();

        visualizer.Add(new Stone(0, 0, Textures.Stone));
        visualizer.Add(new Stairs(20, 0, Textures.Stairs));
        visualizer.Add(new Gold(40, 0, Textures.Gold));
        visualizer.Add(new Rail(60, 0, Textures.Rail));
        visualizer.Add(new GameOver(0, 40, Textures.GameOver));
        visualizer.Start();
    }

    [TestMethod]
    public void WaterDrawTest()
    {
        var water = new Water(40, 40);
        water.AddDynamicState(WaterState.Animated, Animations.Water);
        water.State = WaterState.Animated;

        var visualizer = new ElementVisualizaer();
        visualizer.Add(water);
        visualizer.Start();
    }

    private Player player;
    private Timer timer;

    [TestMethod]
    public void PlayerDrawTest() // todo refactor
    {
        timer = new Timer()
        {
            Interval = 70,
            Enabled = true,
        };
        timer.Elapsed += eh;

        player = new Player(40, 40);
        var visualizer = new ElementVisualizaer();

        visualizer.Add(player);

        visualizer.Start();
    }

    private void eh(object sender, ElapsedEventArgs e)
    {
        player.X += 1;
    }

    [TestMethod]
    public void TestMethod1()
    {
        var tm = new TimerMock();

        var br = new Brick(0, 0);

        var prop = br.GetType().GetField("burn", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        prop.SetValue(br, new Animation(Const.BrickBurnAnimation, Const.BlockSize, new TimerMock()));

        br.Burn();
        tm.NextTick();
        tm.NextTick();
        tm.NextTick();
        tm.NextTick();
    }
}



