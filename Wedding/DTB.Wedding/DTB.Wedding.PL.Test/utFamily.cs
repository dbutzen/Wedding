using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTB.Wedding.PL;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System;

namespace DTB.Wedding.PL.Test
{
    [TestClass]
    public class utFamily
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
            Assert.AreEqual(13, dc.TblFamilies.Count());
        }

        [TestMethod]
        public void InsertTest()
        {
            var row = new TblFamily();
            row.Id = Guid.NewGuid();
            row.Code = "NewCode";
            row.Name = "NewFamily";

            dc.TblFamilies.Add(row);

            var result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var row = dc.TblFamilies.FirstOrDefault();
            if(row != null)
            {
                row.Code = "NewCode";
                dc.SaveChanges();
            }

            var newrow = dc.TblFamilies.FirstOrDefault();

            Assert.AreEqual(row.Code, newrow.Code);
        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            var row = dc.TblFamilies.FirstOrDefault(u => u.Code == "NewCode");
            if(row != null)
            {
                dc.TblFamilies.Remove(row);
                dc.SaveChanges();
            }

            var deletedrow = dc.TblFamilies.FirstOrDefault(u => u.Code == "NewCode");
            Assert.IsNull(deletedrow);
        }
    }
}
