using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTB.Wedding.BL.Models;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DTB.Wedding.API.Test
{
    [TestClass]
    public class utFamily
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

        public void GetTest()
        {
            var families = GetData("Family").ToObject<List<Family>>().ToList().Count;
            Assert.AreEqual(13, families);
        }
    }
}
