﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LodeRunner.Services.Tests
{
    using LodeRunner.Model;
    using System.IO;

    [TestClass()]
    public class ModelLoadServiceTests
    {
        private string path = @"Services\TestFiles\test.lev";
        
        [TestMethod()]
        public void SaveTest()
        {
            File.Delete(path);

            var service = new ModelLoadService();
            service.Save(path, new Model());

            Assert.IsTrue(File.Exists(path));
        }

        [TestMethod]
        public void LoadTest()
        {
            var service = new ModelLoadService();
            var model = service.Load(@"Services\TestFiles\x.lev");

            Assert.AreEqual(2, model.GetAll().Count());
        }
    }
}