using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using LodeRunnerTests.Model.SingleComponents;
using System.Reflection;

namespace LodeRunner.Model.ModelComponents.Tests
{
    [TestClass()]
    public class ComponentsCollectionTests
    {
        private ComponentsCollection pictures;

        [TestInitialize]
        public void SetupTest()
        {
            pictures = new ComponentsCollection();
        }

        [TestMethod]
        public void InitialStateTest()
        {
            pictures = new ComponentsCollection();

            Assert.AreEqual(0, GetInnerList(pictures).Count);
        }

        [TestMethod]
        public void AddTest()
        {
            pictures.Add(new TestPicture());
            pictures.Add(new TestPicture());

            Assert.AreEqual(2, GetInnerList(pictures).Count);
        }

        [TestMethod]
        public void RemoveTest()
        {
            var pic1 = new TestPicture();
            var pic2 = new TestPicture();

            pictures.Add(pic1);
            pictures.Add(pic2);
            pictures.Remove(pic1);
            
            Assert.AreEqual(1, GetInnerList(pictures).Count);
            Assert.AreEqual(pic2, GetInnerList(pictures).First());
        }

        [TestMethod]
        public void GetAllTest()
        {
            pictures.Add(new TestPicture());
            pictures.Add(new TestPicture());

            Assert.AreEqual(typeof(List<TestPicture>), pictures.GetAll<TestPicture>().GetType());
        }

        [TestMethod]
        public void GetTest()
        {
            var testPicture1 = new TestPicture() { X = 1, Y = 5 };
            var testPicture2 = new TestPicture() { X = 8, Y = 1 };

            pictures.Add(testPicture1);
            pictures.Add(testPicture2);

            Assert.IsTrue(testPicture1 == pictures.Get<TestPicture>(1, 5));
            Assert.IsTrue(testPicture2 == pictures.Get<TestPicture>(8, 1));
        }

        // todo how to test it without reflection?
        private List<SingleComponentBase> GetInnerList(object obj)
        {
            FieldInfo listFieldInfo = typeof(ComponentsCollection).GetField("list", BindingFlags.Instance | BindingFlags.NonPublic);

            return (List<SingleComponentBase>)listFieldInfo.GetValue(obj);
        }
    }
}