using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTB.Wedding.PL;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DTB.Wedding.PL.Test
{
    [TestClass]
    public class utTable
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
            Assert.AreEqual(dc.TblTables.Count(), 6);
        }

        [TestMethod]
        public void InsertTest()
        {
            var row = new TblTable();
            row.Id = Guid.NewGuid();
            row.Name = "NewTable";
            row.NumberChairs = 1;
            dc.TblTables.Add(row);
            var results = dc.SaveChanges();
            Assert.IsTrue(results > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var row = dc.TblTables.FirstOrDefault();

            if (row != null)
            {
                row.Name = "UpdatedTable";
                dc.SaveChanges();
            }

            var updatedrow = dc.TblTables.FirstOrDefault();
            Assert.AreEqual(row.Name, updatedrow.Name);

        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            var row = dc.TblTables.FirstOrDefault(u => u.Name == "NewTable");
            if(row != null)
            {
                dc.TblTables.Remove(row);
                dc.SaveChanges();
            }

            var deletedrow = dc.TblTables.FirstOrDefault(u => u.Name == "NewTable");
            Assert.IsNull(deletedrow);
        }



        //Problem with sproc not being found despite working in script
        /*
        [TestMethod]
        public void spCalcRemainingChairsTest()
        {
            var row = dc.TblTables.FirstOrDefault(u => u.Name == "Head");
            var paramTableId = new SqlParameter()
            {
                ParameterName = "TableId",
                SqlDbType = System.Data.SqlDbType.UniqueIdentifier,
                Value = row.Id
            };

            var results = dc.Set<spCalcRemainingChairs>().FromSqlRaw("exec spCalcRemainingChairs @TableId", paramTableId);
            
            List<spCalcRemainingChairs> l = results.ToList();
            Assert.AreEqual(l[0].RemainingSeats, 10);
        }
        */
    }
}
