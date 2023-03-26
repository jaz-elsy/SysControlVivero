using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SysControlVivero.UI.AppWebAspCore.Controllers
{
    public class DetalleVentaController : Controller
    {
        // GET: DetalleVentaController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DetalleVentaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetalleVentaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleVentaController/Create
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

        // GET: DetalleVentaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetalleVentaController/Edit/5
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

        // GET: DetalleVentaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetalleVentaController/Delete/5
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
