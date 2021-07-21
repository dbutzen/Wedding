using DTB.Wedding.BL.Models;
using DTB.Wedding.WebApp.Models;
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
    public class RSVPGuest : Controller
    {
        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://danaudreyweddingapi.azurewebsites.net/");
            return client;
        }

        public ActionResult Index(Guid id)
        {
            HttpClient client = InitializeClient();
            HttpResponseMessage response = client.GetAsync("Guest/" + id).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
            Guest guest = items.ToObject<List<Guest>>()[0];
            FamilyViewModel.guestId = guest.Id;


            return View(guest);
        }
    }
}
