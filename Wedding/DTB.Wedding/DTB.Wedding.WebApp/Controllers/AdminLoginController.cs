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

        public ActionResult Login(User user, string returnurl = null)
        {
            try
            {
                if (UserManager.Login(user) != null)
                {
                    // Successful login
                    /*loggedInUser = user;
                    loggedInUser.SessionKey = Guid.NewGuid();
                    key = JsonConvert.SerializeObject(loggedInUser.SessionKey);
                    HttpContext.Session.SetString(key, user.SessionKey.ToString());*/
                    AuthenticateAdmin.IsAuthenticated = true;

                    if (returnurl == null)
                    {
                        return RedirectToAction("Index", "Review");
                    }
                    else
                    {
                        return Redirect(returnurl);
                    }
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
            /*if (HttpContext.Session.GetString(key) != null) {

                AuthenticateAdmin.IsAuthenticated = false;
            }*/
            AuthenticateAdmin.IsAuthenticated = false;
            return View();
        }
    }
}
