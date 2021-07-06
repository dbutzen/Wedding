using Microsoft.VisualStudio.TestTools.UnitTesting;
using DTB.Wedding.PL;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace DTB.Wedding.PL.Test
{
    [TestClass]
    public class utUser
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
            Assert.AreEqual(dc.TblUsers.Count(), 1);
        }

        [TestMethod]
        public void InsertTest()
        {
            var row = new TblUser();
            row.Id = Guid.NewGuid();
            row.Username = "NewUser";
            row.Password = "pass";
            row.Password = ComputeSha256Hash($"{row.Password}{row.UniqueKey.ToString().ToUpper()}");
            row.UniqueKey = Guid.NewGuid();
            row.SessionKey = Guid.NewGuid();
            dc.TblUsers.Add(row);
            var results = dc.SaveChanges();
            Assert.IsTrue(results > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            InsertTest();
            var row = dc.TblUsers.FirstOrDefault(u => u.Username == "NewUser");

            if (row != null)
            {
                row.Username = "UpdatedUsername";
            }

            var updatedrow = dc.TblUsers.FirstOrDefault();
            Assert.AreEqual(row.Username, updatedrow.Username);

        }

        [TestMethod]
        public void DeleteTest()
        {
            InsertTest();

            var row = dc.TblUsers.FirstOrDefault(u => u.Username == "NewUser");
            if (row != null)
            {
                dc.TblUsers.Remove(row);
                dc.SaveChanges();
            }

            var deletedrow = dc.TblUsers.FirstOrDefault(u => u.Username == "NewUser");
            Assert.IsNull(deletedrow);
        }

        private static string ComputeSha256Hash(string rawData)
        {
            {
                using (var sha = SHA256.Create())
                {
                    var data = sha.ComputeHash(Encoding.Unicode.GetBytes(rawData));

                    var builder = new StringBuilder();

                    foreach (var d in data)
                    {
                        builder.Append(d.ToString("X2"));
                    }
                    return builder.ToString();
                }
            }
        }
    }
}
