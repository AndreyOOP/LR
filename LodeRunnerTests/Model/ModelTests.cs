using LodeRunner.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LodeRunnerTests.Model;
using LodeRunner.Model.ModelComponents;
using LodeRunner.Model.SingleComponents;

namespace LodeRunner.Model.Tests
{
    [TestClass()]
    public class ModelTests
    {
        private TestComponent component;
        private Model model;

        [TestInitialize]
        public void SetupTest()
        {
            model = new Model();
            component = new TestComponent();
        }

        [TestMethod()]
        public void InitialStateTest()
        {
            Assert.AreEqual(0, GetDictionary(model).Values.Count);
        }

        [TestMethod()]
        public void AddTest()
        {
            model.Add(ComponentType.Background, component);
            //model.Add(ComponentType.Brick, collection);

            Assert.AreEqual(1, GetDictionary(model).Values.Count);
        }

        [TestMethod]
        public void AddSameKey()
        {
            Assert.ThrowsException<ArgumentException>(() =>
           {
               model.Add(ComponentType.Background, new TestComponent());
               model.Add(ComponentType.Background, new TestComponent());
           });
        }

        //[TestMethod, Ignore]
        //public void GetTest()
        //{
        //    model.Add(ComponentType.Background, component);
        //    model.Add(ComponentType.Brick, collection);

        //    Assert.AreEqual(collection, model.Get<ComponentsCollection<TestComponent>>(ComponentType.Brick));
        //}

        [TestMethod]
        public void GetAllTest() // todo is it necessary to have get all ? - only for draw but it is possible to do inside class
        {
            model.Add(ComponentType.Background, new TestComponent());
            //model.Add(ComponentType.Brick, new ComponentsCollection<TestComponent>());

            Assert.AreEqual(1, model.GetAll().Count()); // todo return type, convert to list ?
        }

        [TestMethod]
        public void RemoveTest()
        {
            model.Add(ComponentType.Background, component);
            Assert.AreEqual(1, GetDictionary(model).Values.Count);
            //model.Add(ComponentType.Brick, collection);
            model.Remove(ComponentType.Background);

            Assert.AreEqual(0, GetDictionary(model).Values.Count);
        }

        //[TestMethod]
        //public void ReturnedSequenceTest()
        //{
        //    // despite the adding sequence return result has sequence of player > guard > brick > background
        //    // it is match with sequence in ComponentType
        //    // todo looks bad because we depend on inner model structure which is SortedDictionary
        //    // as well it looks too much complexity with model inner structure & ComponentType
        //    model.Remove(ComponentType.Stone);
        //    model.Remove(ComponentType.Water);

        //    model.Add(ComponentType.Brick, new TestComponent("3"));
        //    model.Add(ComponentType.Background, new TestComponent("4"));
        //    model.Add(ComponentType.Guard, new TestComponent("2"));
        //    model.Add(ComponentType.Player, new TestComponent("1"));

        //    var actual = "";
        //    GetDictionary(model).Values.Cast<TestComponent>()
        //                               .Select(component => actual += component.Label)
        //                               .ToList();

        //    Assert.AreEqual("1234", actual);
        //}

        private SortedDictionary<ComponentType, IDrawable> GetDictionary(object obj)
        {
            FieldInfo fi = obj.GetType().GetField("dictionary", BindingFlags.Instance | BindingFlags.NonPublic);

            return (SortedDictionary<ComponentType, IDrawable>)fi.GetValue(obj);
        }

        //[TestMethod()]
        //public void GetComponentTest()
        //{
        //    var bricks = new ComponentsCollection<Brick>();
        //    bricks.Add(new Brick(0, 0));
        //    bricks.Add(new Brick(0, 10));

        //    model.Add(ComponentType.Brick, bricks);

        //    Assert.AreEqual(bricks, model.Get<Brick>());
        //}

        [TestMethod()]
        public void AddSingleComponent()
        {
            var model = new Model();
            model.Add(new Brick(0, 20));

            Assert.AreEqual(true, model.field[0, 1] != null);
            Assert.AreEqual(true, model.field[0, 0] == null);
        }

        [TestMethod()]
        public void ExceptionTest()
        {
            var model = new Model();

            try
            {
                model.Add(new Brick(-45, 20));
            }
            catch(ArgumentException ex)
            {
                Assert.AreEqual("BlockX could not be < 0. Now it is -2", ex.Message);
            }
        }

        [TestMethod()]
        public void ExceptionTest2()
        {
            var model = new Model();

            try
            {
                model.Add(new Brick(440, 20));
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("BlockX could not be >= than maximum field width. It is 22 vs 20", ex.Message);
            }
        }

        [TestMethod()]
        public void ExceptionTestY()
        {
            var model = new Model();

            try
            {
                model.Add(new Brick(0, -20));
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("BlockY could not be < 0. Now it is -1", ex.Message);
            }
        }

        [TestMethod()]
        public void ExceptionTestY2()
        {
            var model = new Model();

            try
            {
                model.Add(new Brick(40, 800));
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("BlockY could not be >= than maximum field width. It is 40 vs 30", ex.Message);
            }
        }

        [TestMethod()]
        public void GetSingleComponent()
        {
            var model = new Model();
            model.Add(new Brick(0, 20));

            Assert.AreEqual(typeof(Brick), model.Get(0, 1).GetType());
        }

        
    }
}