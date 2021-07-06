using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTB.Wedding.BL.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DTB.Wedding.BL.Test
{
    [TestClass]
    public class utFamily
    {
        [TestMethod]
        public void LoadTest()
        {
            var task = FamilyManager.Load();
            task.Wait();
            var results = task.Result;
            Assert.AreEqual(13, results.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            Family family = new Family
            {
                Id = Guid.NewGuid(),
                Name = "NewFamily",
                Code = "NewCode"
            };
            var task = FamilyManager.Insert(family, true);
            task.Wait();

            Assert.IsTrue(task.Result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var loadTask = FamilyManager.Load();
            loadTask.Wait();
            var families = loadTask.Result;
            var family = families.FirstOrDefault(u => u.Code == "AngryZebra");
            family.Code = "StableZebra";
            var task = FamilyManager.Update(family, true);
            task.Wait();

            Assert.IsTrue(task.Result);

        }

        [TestMethod]
        public void DeleteTest()
        {
            var loadTask = FamilyManager.Load();
            loadTask.Wait();
            var families = loadTask.Result;
            var family = families.FirstOrDefault(u => u.Code == "AngryZebra");
            var task = FamilyManager.Delete(family.Id, true);
            task.Wait();

            Assert.IsTrue(task.Result);
        }
    }
}
