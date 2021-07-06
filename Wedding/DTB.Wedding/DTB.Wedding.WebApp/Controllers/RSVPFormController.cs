using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTB.Wedding.WebApp.Controllers
{
    public class RSVPFormController : Controller
    {
        // GET: RSVPFormController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RSVPFormController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RSVPFormController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RSVPFormController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RSVPFormController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RSVPFormController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RSVPFormController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RSVPFormController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
