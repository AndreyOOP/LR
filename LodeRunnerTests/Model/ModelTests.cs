using System;
using LodeRunner.Model;
using LodeRunner.Model.SingleComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class ModelTests
{
    private Model model;

    [TestInitialize]
    public void SetupTest()
    {
        model = new Model();
    }

    [TestMethod]
    public void RemoveTest()
    {
        model.Add(new Brick(0, 20));
        Assert.AreEqual(typeof(Brick), model.Get(0, 1).GetType());

        model.Remove(0, 20, true);
        Assert.IsNull(model.Get(0, 1));
    }

    [TestMethod]
    public void AddSingleComponent()
    {
        model.Add(new Brick(0, 20));

        Assert.AreEqual(true, model.Get(0, 1) != null);
        Assert.AreEqual(true, model.Get(0, 0) == null);
    }

    [TestMethod]
    public void ExceptionTest()
    {
        try
        {
            model.Add(new Brick(-45, 20));
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("BlockX could not be < 0. Now it is -2", ex.Message);
        }
    }

    [TestMethod]
    public void ExceptionTest2()
    {
        try
        {
            model.Add(new Brick(440, 20));
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("BlockX could not be >= than maximum field width. It is 22 vs 20", ex.Message);
        }
    }

    [TestMethod]
    public void ExceptionTestY()
    {
        try
        {
            model.Add(new Brick(0, -20));
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("BlockY could not be < 0. Now it is -1", ex.Message);
        }
    }

    [TestMethod]
    public void ExceptionTestY2()
    {
        try
        {
            model.Add(new Brick(40, 800));
        }
        catch (ArgumentException ex)
        {
            Assert.AreEqual("BlockY could not be >= than maximum field heigth. It is 40 vs 30", ex.Message);
        }
    }

    [TestMethod]
    public void GetSingleComponent()
    {
        model.Add(new Brick(0, 20));

        Assert.AreEqual(typeof(Brick), model.Get(0, 1).GetType());
    }
}