using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival.Controllers
{
    public class DiaDiem_Controller : Controller
    {
        // GET: DiaDiemController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DiaDiemController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DiaDiemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiaDiemController/Create
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

        // GET: DiaDiemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DiaDiemController/Edit/5
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

        // GET: DiaDiemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DiaDiemController/Delete/5
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
