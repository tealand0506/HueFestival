using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HueFestival.Controllers
{
    public class Ve_Controller : Controller
    {
        // GET: Ve_Controller
        public ActionResult Index()
        {
            return View();
        }

        // GET: Ve_Controller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ve_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ve_Controller/Create
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

        // GET: Ve_Controller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ve_Controller/Edit/5
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

        // GET: Ve_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ve_Controller/Delete/5
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
