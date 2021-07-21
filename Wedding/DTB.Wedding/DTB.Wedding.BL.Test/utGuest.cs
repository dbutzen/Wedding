using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTB.Wedding.BL.Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace DTB.Wedding.BL.Test
{
    [TestClass]
    public class utGuest
    {
        [TestMethod]
        public void LoadTest()
        {
            var task = GuestManager.Load();
            task.Wait();
            var results = task.Result;
            Assert.AreEqual(11, results.Count());
        }

        [TestMethod]
        public void LoadById()
        {
            var task = GuestManager.Load();
            task.Wait();
            var results = task.Result;
            task = GuestManager.LoadById(results[0].Id);
            task.Wait();
            var results2 = task.Result;
            Assert.IsNotNull(results2[0].Name != null);
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
            Guest guest = new Guest
            {
                Id = Guid.NewGuid(),
                Name = "NewGuest",
                Attendance = true,
                PlusOneAttendance = false,
                PlusOne = false,
                FamilyId = familyId,
                TableId = tableId,
                Responded = false
            };
            var task = GuestManager.Insert(guest, true);
            task.Wait();

            Assert.IsTrue(task.Result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var loadTask = GuestManager.Load();
            loadTask.Wait();
            var guests = loadTask.Result;
            var guest = guests.FirstOrDefault(u => u.Name == "Maggie Butzen");
            guest.Name = "Margaret Butzen";
            var task = GuestManager.Update(guest, true);
            task.Wait();

            Assert.IsTrue(task.Result);

        }

        [TestMethod]
        public void DeleteTest()
        {
            var loadTask = GuestManager.Load();
            loadTask.Wait();
            var guests = loadTask.Result;
            var guest = guests.FirstOrDefault(u => u.Name == "Maggie Butzen");
            var task = GuestManager.Delete(guest.Id, true);
            task.Wait();

            Assert.IsTrue(task.Result);
        }
    }
}
