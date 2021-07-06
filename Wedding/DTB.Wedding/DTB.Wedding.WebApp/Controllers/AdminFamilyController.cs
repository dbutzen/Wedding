using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTB.Wedding.WebApp.Controllers
{
    public class AdminFamilyController : Controller
    {
        // GET: AdminFamilyController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminFamilyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminFamilyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminFamilyController/Create
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

        // GET: AdminFamilyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminFamilyController/Edit/5
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

        // GET: AdminFamilyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminFamilyController/Delete/5
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
