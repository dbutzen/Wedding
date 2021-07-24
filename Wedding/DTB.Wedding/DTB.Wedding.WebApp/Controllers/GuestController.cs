using DTB.Wedding.BL.Models;
using DTB.Wedding.WebApp.ViewModels;
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
    public class GuestController : Controller
    {
        // GET: GuestController
        private static HttpClient InitializationClient()
        {
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44320/");

            client.BaseAddress = new Uri("https://danaudreyweddingapi.azurewebsites.net/");
            return client;
        }

        public ActionResult Index()
        {
            if (AuthenticateAdmin.IsAuthenticated) { 
            HttpClient client = InitializationClient();

            // Do the actual call to the WebAPI
            HttpResponseMessage reponse = client.GetAsync("Guest").Result;
            //Parse the result
            string result = reponse.Content.ReadAsStringAsync().Result;
            //Parse the result into generic objects
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
            //Pase the items into a list of guest
            List<Guest> guests = items.ToObject<List<Guest>>();
            List<Guest> guestsByName = guests.OrderBy(o => o.Name).ToList();
            ViewBag.Source = "Index";
            return View("Index", guestsByName);
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }
        }

        public ActionResult Details(Guid id)
        {
            if (AuthenticateAdmin.IsAuthenticated) { 
            HttpClient client = InitializationClient();

            // Do the actual call to the WebAPI
            HttpResponseMessage reponse = client.GetAsync("Guest/" + id).Result;
            //Parse the result
            string result = reponse.Content.ReadAsStringAsync().Result;
            //Parse the result into generic objects
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
            List<Guest> guests = items.ToObject<List<Guest>>();

            return View("Details", guests[0]);
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }
        }

        public ActionResult Create()
        {
            if (AuthenticateAdmin.IsAuthenticated) { 
            HttpClient client = InitializationClient();
            GuestFamilyTableViewModel gftvm = new GuestFamilyTableViewModel();
            gftvm.Id = Guid.NewGuid();
            gftvm.Guest = new Guest();

            // Get Families
            HttpResponseMessage reponse = client.GetAsync("Family").Result;
            string result = reponse.Content.ReadAsStringAsync().Result;
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
            List<Family> families = items.ToObject<List<Family>>();
            List<Family> familiesByName = families.OrderBy(o => o.Name).ToList();

            gftvm.Families = familiesByName;
            // Get Tables
            /*
            HttpResponseMessage reponse2 = client.GetAsync("Table").Result;
            string result2 = reponse.Content.ReadAsStringAsync().Result;
            dynamic items2 = (JArray)JsonConvert.DeserializeObject(result);
            List<Table> tables = items.ToObject<List<Table>>();

            gftvm.Tables = tables;
            */
            return View("Create", gftvm);
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }
        }
        [HttpPost]
        public ActionResult Create(GuestFamilyTableViewModel gftvm)
        {
            try
            {
                Guest guest = new Guest()
                {
                    Name = gftvm.Guest.Name,
                    Attendance = false,
                    FamilyId = gftvm.Guest.FamilyId,
                    PlusOne = gftvm.Guest.PlusOne,
                    PlusOneAttendance = false,
                    Responded = false,
                    TableId = Guid.Empty,
                    Id = Guid.NewGuid()

                };
                
                HttpClient client = InitializationClient();
                HttpResponseMessage response = client.PostAsJsonAsync("Guest", guest).Result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Create", gftvm.Guest);
            }

        }

        public ActionResult Edit(Guid id)
        {
            if (AuthenticateAdmin.IsAuthenticated) { 
                HttpClient client = InitializationClient();

                GuestFamilyTableViewModel gftvm = new GuestFamilyTableViewModel();

                HttpResponseMessage response = client.GetAsync("Guest/" + id).Result;
                string result = response.Content.ReadAsStringAsync().Result;
                dynamic items = (JArray)JsonConvert.DeserializeObject(result);
                List<Guest> guests = items.ToObject<List<Guest>>();

                response = client.GetAsync("Family/").Result;
                result = response.Content.ReadAsStringAsync().Result;
                items = (JArray)JsonConvert.DeserializeObject(result);
                List<Family> families = items.ToObject<List<Family>>();

                response = client.GetAsync("Table/").Result;
                result = response.Content.ReadAsStringAsync().Result;
                items = (JArray)JsonConvert.DeserializeObject(result);
                List<Table> tables = items.ToObject<List<Table>>();

                gftvm.Families = families;
                gftvm.Tables = tables;
                gftvm.Id = id;
                gftvm.Guest = guests[0];



            return View("Edit", gftvm);
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }
        }



        [HttpPost]
        public ActionResult Edit(Guid id, Guest guest)
        {
            try
            {
                HttpClient client = InitializationClient();
                HttpResponseMessage response = client.PutAsJsonAsync("Guest/" + id, guest).Result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Edit", guest);
            }

        }

        public ActionResult Delete(Guid id)
        {
            if (AuthenticateAdmin.IsAuthenticated) { 
            HttpClient client = InitializationClient();
            HttpResponseMessage response = client.GetAsync("Guest/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
            List<Guest> guests = items.ToObject<List<Guest>>();
            return View("Delete", guests[0]);
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }
        }

        [HttpPost]
        public ActionResult Delete(Guid id, Guest guest)
        {
            try
            {
                HttpClient client = InitializationClient();
                HttpResponseMessage response = client.DeleteAsync("Guest/" + id).Result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Delete", guest);
            }

        }
    }
}
