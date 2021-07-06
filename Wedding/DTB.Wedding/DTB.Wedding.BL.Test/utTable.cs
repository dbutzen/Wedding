using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTB.Wedding.BL.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DTB.Wedding.BL.Test
{
    [TestClass]
    public class utTable
    {
        [TestMethod]
        public void LoadTest()
        {
            var task = TableManager.Load();
            task.Wait();
            var results = task.Result;
            Assert.AreEqual(7, results.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            var loadTask = FamilyManager.Load();
            loadTask.Wait();
            var familyId = loadTask.Result.FirstOrDefault().Id;
            var loadTableTask = TableManager.Load();
            loadTableTask.Wait();
            var tableId = loadTableTask.Result.FirstOrDefault().Id;
            Table table = new Table
            {
                Id = Guid.NewGuid(),
                Name = "NewTable",
                NumberChairs = 1
            };
            var task = TableManager.Insert(table, true);
            task.Wait();

            Assert.IsTrue(task.Result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var loadTask = TableManager.Load();
            loadTask.Wait();
            var tables = loadTask.Result;
            var table = tables.FirstOrDefault(u => u.Name == "Head");
            table.Name = "Throne";
            var task = TableManager.Update(table, true);
            task.Wait();

            Assert.IsTrue(task.Result);

        }

        [TestMethod]
        public void DeleteTest()
        {
            var loadTask = TableManager.Load();
            loadTask.Wait();
            var tables = loadTask.Result;
            var table = tables.FirstOrDefault(u => u.Name == "Head");
            var task = TableManager.Delete(table.Id, true);
            task.Wait();

            Assert.IsTrue(task.Result);
        }
    }
}
