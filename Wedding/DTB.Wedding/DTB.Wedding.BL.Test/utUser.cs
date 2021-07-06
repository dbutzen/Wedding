using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using DTB.Wedding.BL;
using DTB.Wedding.BL.Models;

namespace DTB.Wedding.BL.Test
{
    [TestClass]
    public class utUser
    {

        [TestMethod]
        public void LoadTest()
        {

            var task = UserManager.Load();
            task.Wait();
            var results = task.Result;
            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            var task = UserManager.LoadByUsername("Admin");
            task.Wait();
            var id = task.Result.Id;

            task = UserManager.LoadById(id);
            task.Wait();
            var results = task.Result;
            Assert.AreEqual(id, results.Id);
        }

        [TestMethod]
        public void LoadByUsernameTest()
        {
            var task = UserManager.LoadByUsername("Admin");
            task.Wait();
            var results = task.Result;
            Assert.AreEqual("Admin", results.Username);
        }

        [TestMethod]
        public void LoadBySessionKeyTest()
        {
            var user = new User();
            user.Username = "Admin";
            user.Password = "admin";
            var loginTask = UserManager.Login(user, false, true);
            loginTask.Wait();
            var sessionKey = loginTask.Result;

            var task = UserManager.LoadBySessionKey(sessionKey);
            task.Wait();
            var results = task.Result;
            Assert.AreEqual("Admin", results.Username);
        }

        [TestMethod]
        public void LoginTest()
        {
            var user = new User();
            user.Username = "Admin";
            user.Password = "admin";
            var task = UserManager.Login(user, false, false);
            task.Wait();
            Assert.IsTrue(task.Result != Guid.Empty);
        }

        [TestMethod]
        public void ChangePasswordTest()
        {
            var loadTask = UserManager.LoadByUsername("Admin");
            loadTask.Wait();
            var user = loadTask.Result;
            user.Password = "admin"; // <-- Old password must be entered
            var task = UserManager.ChangePassword(user, "newpass", true);
            task.Wait();
            Assert.IsTrue(task.Result > 0);
        }


        [TestMethod]
        public void InsertTest()
        {
            var user = new User();
            user.Username = "newuser123";
            user.Password = "pass";

            var task = UserManager.Insert(user, true);
            task.Wait();

            Assert.IsTrue(task.Result);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var loadTask = UserManager.Load();
            loadTask.Wait();
            var users = loadTask.Result;
            var user = users.FirstOrDefault(u => u.Username == "Admin");
            user.Username = "Updated User";
            user.SessionKey = Guid.NewGuid();
            var task = UserManager.Update(user, true);
            task.Wait();

            Assert.IsTrue(task.Result);
        }

        [TestMethod]
        public void DeleteTest()
        {
            var loadTask = UserManager.Load();
            loadTask.Wait();
            var users = loadTask.Result;

            var user = users.FirstOrDefault(u => u.Username == "Admin");
            var task = UserManager.Delete(user.Id, true);
            task.Wait();

            Assert.IsTrue(task.Result);
        }



    }
}
