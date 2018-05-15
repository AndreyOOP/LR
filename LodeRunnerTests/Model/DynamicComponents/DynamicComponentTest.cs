using LodeRunnerTests;
using LodeRunner.Animation;
using System.Collections.Generic;
using LodeRunner.Model.DynamicComponents;
using LodeRunner.Model.SingleComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using LodeRunnerTests.Model.DynamicComponents;
using LodeRunner;
using LodeRunnerTests.Animation;

// todo how to test ?
[TestClass]
public class DynamicComponentTest
{
    private TimerMock timer1;
    private TimerMock timer2;
    private Dictionary<BrickState, Animation> dynamicStates;
    private Dictionary<BrickState, Image> staticStates;
    private DynamicComponent<BrickState> component;

    [TestInitialize]
    public void Setup()
    {
        staticStates = new Dictionary<BrickState, Image>();
        dynamicStates = new Dictionary<BrickState, Animation>();

        timer1 = new TimerMock();
        timer2 = new TimerMock();
        var burnMock = new AnimationMock(Const.BrickTexture, Const.BlockSize, timer1);
        var growMock = new AnimationMock(Const.BrickTexture, Const.BlockSize, timer2);

        component = new DynamicComponent<BrickState>(0, 0);
        component.AddDynamicState(BrickState.Burn, burnMock);
        component.AddDynamicState(BrickState.Grow, growMock);
        component.State = BrickState.Visible;
    }

    [TestMethod]
    public void InitialState()
    {
        Assert.AreEqual(BrickState.Visible, Reflection.GetPrivateField<BrickState>(component, "state"));
    }

    [TestMethod]
    public void StateChange()
    {
        component.State = BrickState.Grow;       
        Assert.AreEqual(AnimationMockState.Started, ((AnimationMock)GetValue(component, BrickState.Grow)).InnerState);
    }

    private Animation GetValue(object obj, BrickState key)
    {
        var dictionary = Reflection.GetPrivateField<Dictionary<BrickState, Animation>>(component, "dynamicStates");
        return dictionary[key];
    }
}