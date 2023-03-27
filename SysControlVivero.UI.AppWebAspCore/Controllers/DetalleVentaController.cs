using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
//****************
using SysControlVivero.EntidadesDeNegocio;
using SysControlVivero.LogicaDeNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using SysControlVivero.AccesoADatos;

namespace SysControlVivero.UI.AppWebAspCore.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class DetalleVentaController : Controller
    {
        
        DetalleVentaBL _detalleventaBL = new DetalleVentaBL();

        // GET: FacturaController
        public async Task<IActionResult> Index(DetalleVenta pDetalleVenta = null)
        {
            if (pDetalleVenta == null)
                pDetalleVenta = new DetalleVenta();
            if (pDetalleVenta.Top_Aux == 0)
                pDetalleVenta.Top_Aux = 10;
            else if (pDetalleVenta.Top_Aux == -1)
                pDetalleVenta.Top_Aux = 0;
            var detalleventas = await _detalleventaBL.BuscarAsync(pDetalleVenta);
            ViewBag.Top = pDetalleVenta.Top_Aux;
            return View(detalleventas);


        }


        // GET: FacturaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var detalleventa = await _detalleventaBL.ObtenerPorIdAsync(new DetalleVenta { IdDetalleVenta = id });
            return View(detalleventa);
        }


        // GET: FacturaController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: FacturaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(DetalleVenta pDetalleVenta)
        {
            try
            {
                int result = await _detalleventaBL.CrearAsync(pDetalleVenta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pDetalleVenta);
            }
        }
        // GET: DetalleVentaController/Edit/5
        public async Task<IActionResult> Edit(DetalleVenta pDetalleVenta)
        {
            var detalleventa = await _detalleventaBL.ObtenerPorIdAsync(pDetalleVenta);
            ViewBag.Error = "";

            return View(detalleventa);
        }

        // POST: DetalleVentaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DetalleVenta pDetalleVenta)
        {
            try
            {
                int result = await _detalleventaBL.ModificarAsync(pDetalleVenta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pDetalleVenta);

            }
        }

        // GET: DetalleVentaController/Delete/5
        public async Task<IActionResult> Delete(DetalleVenta pDetalleVenta)
        {
            ViewBag.Error = "";
            var detalleventa = await _detalleventaBL.ObtenerPorIdAsync(pDetalleVenta);
            return View(detalleventa);
        }

        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, DetalleVenta pDetalleVenta)
        {
            try
            {
                int result = await _detalleventaBL.EliminarAsync(pDetalleVenta);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pDetalleVenta);
            }
        }
    }
}
        

