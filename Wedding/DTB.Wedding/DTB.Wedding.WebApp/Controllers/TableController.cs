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
    public class TableController : Controller
    {
        // GET: TableController
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
            HttpResponseMessage reponse = client.GetAsync("Table").Result;
            //Parse the result
            string result = reponse.Content.ReadAsStringAsync().Result;
            //Parse the result into generic objects
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
            //Pase the items into a list of table
            List<Table> tables = items.ToObject<List<Table>>();
            List<Table> tablesByName = tables.OrderBy(o => o.Name).ToList();
            ViewBag.Source = "Index";
            return View("Index", tablesByName);
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
            HttpResponseMessage reponse = client.GetAsync("Table/" + id).Result;
            //Parse the result
            string result = reponse.Content.ReadAsStringAsync().Result;
            //Parse the result into generic objects
            Table table = JsonConvert.DeserializeObject<Table>(result);

            return View("Details", table);
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

            Table table = new Table();
            return View("Create", table);
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }
        }
        [HttpPost]
        public ActionResult Create(Table table)
        {
            try
            {
                HttpClient client = InitializationClient();
                HttpResponseMessage response = client.PostAsJsonAsync("Table", table).Result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Create", table);
            }

        }

        public ActionResult Edit(Guid id)
        {
            if (AuthenticateAdmin.IsAuthenticated) { 
            HttpClient client = InitializationClient();


            HttpResponseMessage response = client.GetAsync("Table/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Table table = JsonConvert.DeserializeObject<Table>(result);

            return View("Edit", table);
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }
        }



        [HttpPost]
        public ActionResult Edit(Guid id, Table table)
        {
            try
            {
                HttpClient client = InitializationClient();
                HttpResponseMessage response = client.PutAsJsonAsync("Table/" + id, table).Result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Edit", table);
            }

        }

        public ActionResult Delete(Guid id)
        {
            if (AuthenticateAdmin.IsAuthenticated) { 
            HttpClient client = InitializationClient();
            HttpResponseMessage response = client.GetAsync("Table/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            Table table = JsonConvert.DeserializeObject<Table>(result);
            return View("Delete", table);
            }
            else
            {
                return RedirectToAction("Login", "AdminLogin");
            }
        }

        [HttpPost]
        public ActionResult Delete(Guid id, Table table)
        {
            
            try
            {
                HttpClient client = InitializationClient();
                // Get guests
                HttpResponseMessage response = client.GetAsync("Guest").Result;
                string result = response.Content.ReadAsStringAsync().Result;
                List<Guest> guests = JsonConvert.DeserializeObject<List<Guest>>(result);
                // Get tables
                response = client.GetAsync("Table").Result;
                result = response.Content.ReadAsStringAsync().Result;
                List<Table> tables = JsonConvert.DeserializeObject<List<Table>>(result);
                Table floatTable = new Table();
                // Get float table
                foreach(Table t in tables)
                {
                    if (t.Name == "Float")
                    {
                        floatTable = t;
                    }
                }
                // Set Id's of guests with deleted table to float table
                foreach (Guest g in guests)
                {
                    if (g.TableId == table.Id)
                    {
                        g.TableId = floatTable.Id;
                        client.PutAsJsonAsync("Guest/" + g.Id, g);
                    }
                }

                // Deletes table
                response = client.DeleteAsync("Table/" + id).Result;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Delete", table);
            }

        }
    }
}
