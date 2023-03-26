using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SysControlVivero.UI.AppWebAspCore.Controllers
{
    public class EmpleadoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        // GET: EmpleadoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: EmpleadoController/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: EmpleadoContoller/Create
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

        // GET: EmpleadoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        // POST: EmpleadoController/Edit/5
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
        // GET: EmpleadoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        // POST: EmpleadoController/Delete/5
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
