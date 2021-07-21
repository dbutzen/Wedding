using DTB.Wedding.BL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DTB.Wedding.API.Test
{
    [TestClass]
    public class utGuest
    {
        private HttpClient InitializeClient()
        {
            var client = new HttpClient();
            //client.BaseAddress = new Uri("https://localhost:44320/");
            client.BaseAddress = new Uri("http://danaudreyweddingapi.azurewebsites.net/");
            return client;
        }

        private JArray GetData(string controller)
        {
            HttpClient client = InitializeClient();
            HttpResponseMessage response;
            string result;
            response = client.GetAsync(controller).Result;
            result = response.Content.ReadAsStringAsync().Result;
            return (JArray)JsonConvert.DeserializeObject(result);
        }

        [TestMethod]

        public void GetById()
        {
            var guests = GetData("Guest").ToObject<List<Guest>>().ToList();
            Guid id = guests[0].Id;
            var guest = GetData("Guest/" + id).ToObject<List<Guest>>().ToList().Count;
            Assert.AreEqual(1, guest);
        }
    }
}
