using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTB.Wedding.WebApp.Controllers
{
    public class AdminTableController : Controller
    {
        // GET: AdminTableController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AdminTableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminTableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminTableController/Create
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

        // GET: AdminTableController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminTableController/Edit/5
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

        // GET: AdminTableController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminTableController/Delete/5
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
