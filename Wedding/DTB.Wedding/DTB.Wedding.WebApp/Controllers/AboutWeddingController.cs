using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTB.Wedding.WebApp.Controllers
{
    public class AboutWeddingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
