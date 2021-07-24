using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTB.Wedding.BL.Models;
using Newtonsoft.Json;
using DTB.Wedding.WebApp.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DTB.Wedding.WebApp.Controllers
{
    public class AdminLoginController : Controller
    {
        public string key { get; set; }
        public User loggedInUser { get; set; }

        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://danaudreyweddingapi.azurewebsites.net/");
            return client;
        }

       

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
                HttpClient client = InitializeClient();
                HttpResponseMessage response = client.GetAsync("User/" + user.Username).Result;
                var result = response.Content.ReadAsStringAsync().Result;
                dynamic item = (JObject)JsonConvert.DeserializeObject(result);
                User userDB = item.ToObject<User>();

                if (ComputeSha256Hash($"{user.Password}{userDB.UniqueKey.ToString().ToUpper()}") == userDB.Password )
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
                ViewBag.Message = "Invalid User or Password";
                return RedirectToAction("Login", "AdminLogin"); ;
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                //return View(user);
                return RedirectToAction("Login", "AdminLogin");
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

        private static string ComputeSha256Hash(string rawData)
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
