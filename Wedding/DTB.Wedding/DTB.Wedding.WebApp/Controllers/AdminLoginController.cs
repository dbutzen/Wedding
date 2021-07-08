using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTB.Wedding.BL;
using DTB.Wedding.BL.Models;
using Newtonsoft.Json;
using DTB.Wedding.WebApp.Models;

namespace DTB.Wedding.WebApp.Controllers
{
    public class AdminLoginController : Controller
    {
        public string key { get; set; }
        public User loggedInUser { get; set; }

        public ActionResult Login(string returnurl)
        {
            ViewBag.ReturnUrl = returnurl;
            return View();
        }

        [HttpPost]

        public ActionResult Login(User user, string returnurl)
        {
            try
            {
                if (UserManager.Login(user) != null)
                {
                    // Successful login
                    loggedInUser = user;
                    loggedInUser.SessionKey = Guid.NewGuid();
                    key = JsonConvert.SerializeObject(loggedInUser.SessionKey);
                    HttpContext.Session.SetString(key, user.SessionKey.ToString());
                    AuthenticateAdmin.IsAuthenticated = true;
                    return RedirectToPage("/Family/Index");
                }
                return View(user);
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            if (HttpContext.Session.GetString(key) != null) {

                loggedInUser.SessionKey = Guid.Empty;
                HttpContext.Session.Remove(key);
                key = null;
                AuthenticateAdmin.IsAuthenticated = false;
            }
            return View();
        }
    }
}
