using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTB.Wedding.PL.Test
{
    [TestClass]
    public class utGuest
    {

        protected WeddingEntities dc;
        protected IDbContextTransaction transaction;

        [TestInitialize]
        public void TestInitialize()
        {
            dc = new WeddingEntities();
            transaction = dc.Database.BeginTransaction();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            transaction.Rollback();
            transaction.Dispose();
        }

        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(11, dc.TblGuests.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            var row = new TblGuest();

            row.Id = Guid.NewGuid();
            row.FamilyId = dc.TblFamilies.FirstOrDefault().Id;
            row.TableId = dc.TblTables.FirstOrDefault().Id;
            row.Attendance = true;
            row.Name = "NewName";
            row.PlusOneAttendance = false;
            row.PlusOne = false;
            row.Responded = false;

            dc.TblGuests.Add(row);

            var results = dc.SaveChanges();

            Assert.IsTrue(results > 0);

        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();

            var row = dc.TblGuests.FirstOrDefault(u => u.Name == "NewName");

            if (row != null)
            {
                row.Name = "UpdatedName";
                dc.SaveChanges();
            }

            var updatedrow = dc.TblGuests.FirstOrDefault(u => u.Name == "UpdatedName");
            Assert.AreEqual(row.Name, updatedrow.Name);

        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            var row = dc.TblGuests.FirstOrDefault(u => u.Name == "NewName");

            if(row != null)
            {
                dc.TblGuests.Remove(row);
                dc.SaveChanges();
            }

            var deletedrow = dc.TblGuests.FirstOrDefault(u => u.Name == "NewName");

            Assert.IsNull(deletedrow);

        }
    }
}
