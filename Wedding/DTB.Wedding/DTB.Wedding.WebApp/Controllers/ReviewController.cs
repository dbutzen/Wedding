using DTB.Wedding.BL.Models;
using DTB.Wedding.WebApp.Models;
using DTB.Wedding.WebApp.ViewModels;
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
    public class ReviewController : Controller
    {

        private static HttpClient InitializationClient()
        {
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44320/");

            client.BaseAddress = new Uri("https://danaudreyweddingapi.azurewebsites.net/");
            return client;
        }

        public ActionResult Index()
        {
            List<FamilyGuestViewModel> fgvms = new List<FamilyGuestViewModel>();
            WeddingViewModel wvm = new WeddingViewModel();
            wvm.Id = Guid.NewGuid();

            HttpClient client = InitializationClient();
            HttpResponseMessage responseGuest = client.GetAsync("Guest").Result;
            string resultGuest = responseGuest.Content.ReadAsStringAsync().Result;
            dynamic items = (JArray)JsonConvert.DeserializeObject(resultGuest);
            List<Guest> guests = items.ToObject<List<Guest>>();
            
            HttpResponseMessage responseFamily = client.GetAsync("Family").Result;
            string resultFamily = responseFamily.Content.ReadAsStringAsync().Result;
            items = (JArray)JsonConvert.DeserializeObject(resultFamily);
            List<Family> families = items.ToObject<List<Family>>();
            
            foreach(Family family in families)
            {
                FamilyGuestViewModel fgvm = new FamilyGuestViewModel();
                List<Guest> familyGuests = new List<Guest>();
                foreach(Guest guest in guests)
                {
                    if (guest.FamilyId == family.Id)
                    {
                        familyGuests.Add(guest);
                    }
                }

                fgvm.id = Guid.NewGuid();
                fgvm.family = family;
                fgvm.guests = familyGuests;
                fgvms.Add(fgvm);
            }
            wvm.families = fgvms;

            return View(wvm);

        }
    }
}
