﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival.Controllers
{
    public class Nhom_CTr_Controller : Controller
    {
        // GET: Nhom_CTr_Controller
        public ActionResult Index()
        {
            return View();
        }

        // GET: Nhom_CTr_Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Nhom_CTr_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nhom_CTr_Controller/Create
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

        // GET: Nhom_CTr_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Nhom_CTr_Controller/Edit/5
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

        // GET: Nhom_CTr_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Nhom_CTr_Controller/Delete/5
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
