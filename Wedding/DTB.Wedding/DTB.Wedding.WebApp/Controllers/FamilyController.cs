using DTB.Wedding.BL;
using DTB.Wedding.BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DTB.Wedding.WebApp.Controllers
{
    public class FamilyController : Controller
    {
        // GET: FamilyController
        private static HttpClient InitializationClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44320/");

            //client.BaseAddress = new Uri("https://danaudreyweddingapi.azurewebsites.net/");
            return client;
        }

        public ActionResult Get()
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

            ViewBag.Source = "Get";
            return View("Index", families);

        }

        public ActionResult GetOne(int id)
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

        public ActionResult Insert()
        {
            HttpClient client = InitializationClient();

            Family family = new Family();
            return View("Create", family);
        }
        [HttpPost]
        public ActionResult Insert(Family family)
        {
            try
            {
                HttpClient client = InitializationClient();
                HttpResponseMessage response = client.PostAsJsonAsync("Family", family).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Create", family);
            }

        }

        public ActionResult Update(int id)
        {
            HttpClient client = InitializationClient();


            HttpResponseMessage response = client.GetAsync("Family/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Family family = JsonConvert.DeserializeObject<Family>(result);

            return View("Edit", family);
        }



        [HttpPost]
        public ActionResult Update(int id, Family family)
        {
            try
            {
                HttpClient client = InitializationClient();
                HttpResponseMessage response = client.PutAsJsonAsync("Family/" + id, family).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Edit", family);
            }

        }

        public ActionResult Remove(int id)
        {
            HttpClient client = InitializationClient();
            HttpResponseMessage response = client.GetAsync("Family/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Family family = JsonConvert.DeserializeObject<Family>(result);
            return View("Delete", family);
        }

        [HttpPost]
        public ActionResult Remove(int id, Family family)
        {
            try
            {
                HttpClient client = InitializationClient();
                HttpResponseMessage response = client.DeleteAsync("Family/" + id).Result;
                return RedirectToAction("Get");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Delete", family);
            }

        }
    }
}
