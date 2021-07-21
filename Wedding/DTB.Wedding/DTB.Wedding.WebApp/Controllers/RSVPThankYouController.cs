using DTB.Wedding.BL.Models;
using DTB.Wedding.WebApp.Models;
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
    public class RSVPThankYouController : Controller
    {

        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://danaudreyweddingapi.azurewebsites.net/");
            return client;
        }
        public IActionResult Index(Guid id)
        {
            HttpClient client = InitializeClient();

            string guestId = Request.Form["Id"].ToString();

            HttpResponseMessage response = client.GetAsync("Guest/" + guestId).Result;
            string result = response.Content.ReadAsStringAsync().Result;
            dynamic items = (JArray)JsonConvert.DeserializeObject(result);
            Guest guest = items.ToObject<List<Guest>>()[0];

            if(Request.Form["rdoAttendance"].ToString() == "Yes!")
            {
                guest.Attendance = true;
            }
            else
            {
                guest.Attendance = false;
            }
            if(Request.Form["rdoPlusOneAttendance"].ToString() != null)
            {
                if(Request.Form["rdoPlusOneAttendance"].ToString() == "Yes!")
                {
                    guest.PlusOneAttendance = true;
                }
                else
                {
                    guest.PlusOneAttendance = false;
                }
            }
            guest.Responded = true;
            try
            {
                HttpResponseMessage response2 = client.PutAsJsonAsync("Guest/" + id, guest).Result;
                /*Family family = new Family
                {
                    Id = Guid.NewGuid(),
                    Code = FamilyViewModel.familyCode,
                    Name = "Placeholder"
                };*/
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Index", guest);
            }
            


        }
    }
}
