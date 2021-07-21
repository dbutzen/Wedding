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
    public class CodeEntryController : Controller
    {
        private static HttpClient InitializeClient()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://danaudreyweddingapi.azurewebsites.net/");
            return client;
        }

        // GET: CodeEntryController
        public ActionResult Index()
        {
            return View();
        }

        
    }
}
