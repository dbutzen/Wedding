using DTB.Wedding.BL.Models;
using DTB.Wedding.WebApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace DTB.Wedding.WebApp.Controllers
{
    public class FamilyController : Controller
    {
        // GET: FamilyController
        private static HttpClient InitializationClient()
        {
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44320/");

            client.BaseAddress = new Uri("https://danaudreyweddingapi.azurewebsites.net/");
            return client;
        }

        public ActionResult Index()
        {
            if (AuthenticateAdmin.IsAuthenticated == true)
            {
                HttpClient client = InitializationClient();

                // Do the actual call to the WebAPI
                HttpResponseMessage reponse = client.GetAsync("Family").Result;
                //Parse the result
                string result = reponse.Content.ReadAsStringAsync().Result;
                //Parse the result into generic objects
                dynamic items = (JArray)JsonConvert.DeserializeObject(result);
                //Pase the items into a list of family
                List<Family> families = items.ToObject<List<Family>>();
                List<Family> familiesByName = families.OrderBy(o => o.Name).ToList();
                ViewBag.Source = "Index";
                return View("Index", familiesByName);
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }

            
        }

        public ActionResult Details(Guid id)
        {
            if(AuthenticateAdmin.IsAuthenticated == true) 
            { 
            HttpClient client = InitializationClient();

            // Do the actual call to the WebAPI
            HttpResponseMessage reponse = client.GetAsync("Family/" + id).Result;
            //Parse the result
            string result = reponse.Content.ReadAsStringAsync().Result;
            //Parse the result into generic objects
            Family family = JsonConvert.DeserializeObject<Family>(result);

            return View("Details", family);
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }
        }

        public ActionResult Create()
        {
            if (AuthenticateAdmin.IsAuthenticated == true) { 
            HttpClient client = InitializationClient();

            Family family = new Family();
            return View("Create", family);
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }
        }
        [HttpPost]
        public ActionResult Create(Family family)
        {
            try
            {
                HttpClient client = InitializationClient();
                HttpResponseMessage response = client.PostAsJsonAsync("Family", family).Result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Create", family);
            }

        }

        public ActionResult Edit(Guid id)
        {
            if (AuthenticateAdmin.IsAuthenticated) { 
            HttpClient client = InitializationClient();


            HttpResponseMessage response = client.GetAsync("Family/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Family family = JsonConvert.DeserializeObject<Family>(result);

            return View("Edit", family);
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }
        }



        [HttpPost]
        public ActionResult Edit(Guid id, Family family)
        {
            try
            {
                HttpClient client = InitializationClient();
                HttpResponseMessage response = client.PutAsJsonAsync("Family/" + id, family).Result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Edit", family);
            }

        }

        public ActionResult Delete(Guid id)
        {
            if (AuthenticateAdmin.IsAuthenticated) { 
            HttpClient client = InitializationClient();
            HttpResponseMessage response = client.GetAsync("Family/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Family family = JsonConvert.DeserializeObject<Family>(result);
            return View("Delete", family);
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }
        }

        [HttpPost]
        public ActionResult Delete(Guid id, Family family)
        {
            try
            {
                HttpClient client = InitializationClient();
                HttpResponseMessage response = client.DeleteAsync("Family/" + id).Result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Delete", family);
            }

        }
    }
}
