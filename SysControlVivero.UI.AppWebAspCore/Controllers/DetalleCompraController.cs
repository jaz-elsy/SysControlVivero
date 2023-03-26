using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SysControlVivero.UI.AppWebAspCore.Controllers
{
    public class DetalleCompraController : Controller
    {
        // GET: DetalleCompraController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DetalleCompraController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetalleCompraController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetalleCompraController/Create
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

        // GET: DetalleCompraController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetalleCompraController/Edit/5
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

        // GET: DetalleCompraController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetalleCompraController/Delete/5
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
