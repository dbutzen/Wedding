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
using System.Threading.Tasks;

namespace DTB.Wedding.WebApp.Controllers
{
    public class RSVPFormController : Controller
    {

        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://danaudreyweddingapi.azurewebsites.net/");
            return client;
        }
        // GET: RSVPFormController
        public ActionResult Index()
        {
            try
            {
                string familyCode = Request.Form["txtFamilyCode"].ToString();
                FamilyViewModel.familyCode = familyCode;


                HttpClient client = InitializeClient();
                HttpResponseMessage response;
                string result;
                dynamic items;

                List<Guest> guests = null;
                FamilyViewModel familyViewModel = new FamilyViewModel();

                response = client.GetAsync("Guest/" + familyCode).Result;

                result = response.Content.ReadAsStringAsync().Result;
                items = (JArray)JsonConvert.DeserializeObject(result);
                guests = items.ToObject<List<Guest>>();


                FamilyViewModel.guestsInFamily = guests;

                return View(guests);
            }
            catch (Exception)
            {

                throw new Exception("Error with activation code. Codes are case sensitive and do not include spaces.");
            }
        }

        
    }
}
