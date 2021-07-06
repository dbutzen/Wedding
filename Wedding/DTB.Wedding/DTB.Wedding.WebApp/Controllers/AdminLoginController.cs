using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTB.Wedding.BL;
using DTB.Wedding.BL.Models;

namespace DTB.Wedding.WebApp.Controllers
{
    public class AdminLoginController : Controller
    {
        

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
                if (UserManager.Login(user))
                {
                    // Successful login
                    Session["user"] = user;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
