﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival.Controllers
{
    public class Loai_Ve_Controller : Controller
    {
        // GET: Loai_Ve_Controller
        public ActionResult Index()
        {
            return View();
        }

        // GET: Loai_Ve_Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Loai_Ve_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Loai_Ve_Controller/Create
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

        // GET: Loai_Ve_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Loai_Ve_Controller/Edit/5
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

        // GET: Loai_Ve_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Loai_Ve_Controller/Delete/5
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