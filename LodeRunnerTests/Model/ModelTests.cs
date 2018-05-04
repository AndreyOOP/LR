using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LodeRunnerTests.Model;
using LodeRunner.Model.ModelComponents;

namespace LodeRunner.Model.Tests
{
    [TestClass()]
    public class ModelTests
    {
        private TestComponent component;
        private ComponentsCollection<TestComponent> collection;
        private Model model;

        [TestInitialize]
        public void SetupTest()
        {
            model = new Model();
            component = new TestComponent();
            collection = new ComponentsCollection<TestComponent>();
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
            model.Add(ComponentType.Brick, collection);

            Assert.AreEqual(2, GetDictionary(model).Values.Count);
        }

        [TestMethod]
        public void AddSameKey()
        {
            Assert.ThrowsException<ArgumentException>( () =>
            {
                model.Add(ComponentType.Background, new TestComponent());
                model.Add(ComponentType.Background, new TestComponent());
            });
        }

        [TestMethod]
        public void GetTest()
        {
            model.Add(ComponentType.Background, component);
            model.Add(ComponentType.Brick, collection);

            Assert.AreEqual(collection, model.Get<ComponentsCollection<TestComponent>>(ComponentType.Brick));
        }

        [TestMethod]
        public void GetAllTest() // todo is it necessary to have get all ? - only for draw but it is possible to do inside class
        {
            model.Add(ComponentType.Background, new TestComponent());
            model.Add(ComponentType.Brick, new ComponentsCollection<TestComponent>());

            Assert.AreEqual(2, model.GetAll().Count()); // todo return type, convert to list ?
        }

        [TestMethod]
        public void RemoveTest()
        {
            model.Add(ComponentType.Background, component);
            model.Add(ComponentType.Brick, collection);
            model.Remove(ComponentType.Background);

            Assert.AreEqual(collection, GetDictionary(model).Values.First());
        }

        [TestMethod]
        public void ReturnedSequenceTest()
        {
            // despite the adding sequence return result has sequence of player > guard > brick > background
            // it is match with sequence in ComponentType
            // todo looks bad because we depend on inner model structure which is SortedDictionary
            // as well it looks too much complexity with model inner structure & ComponentType
            model.Add(ComponentType.Brick     , new TestComponent("3"));
            model.Add(ComponentType.Background, new TestComponent("4"));
            model.Add(ComponentType.Guard     , new TestComponent("2"));
            model.Add(ComponentType.Player    , new TestComponent("1"));

            var actual = "";
            GetDictionary(model).Values.Cast<TestComponent>()
                                       .Select(component => actual += component.Label)
                                       .ToList();

            Assert.AreEqual("1234", actual);
        }

        private SortedDictionary<ComponentType, IDrawable> GetDictionary(object obj)
        {
            FieldInfo fi = obj.GetType().GetField("dictionary", BindingFlags.Instance | BindingFlags.NonPublic);

            return (SortedDictionary<ComponentType, IDrawable>)fi.GetValue(obj);
        }
    }
}