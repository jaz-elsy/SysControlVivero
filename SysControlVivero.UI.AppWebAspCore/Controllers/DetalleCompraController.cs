using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using SysControlVivero.EntidadesDeNegocio;
using SysControlVivero.LogicaDeNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using SysControlVivero.AccesoADatos;

namespace SysControlVivero.UI.AppWebAspCore.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class DetalleCompraController : Controller
    {
        DetalleCompraBL detallecompraBL = new DetalleCompraBL();
        // GET: DetalleCompraController
        public async Task<IActionResult> Index(DetalleCompra pCompras = null)
        {
            if (pCompras == null)
                pCompras = new DetalleCompra();
            if (pCompras.Top_Aux == 0)
                pCompras.Top_Aux = 10;
            else if (pCompras.Top_Aux == -1)
                pCompras.Top_Aux = 0;
            var roles = await detallecompraBL.BuscarAsync(pCompras);
            ViewBag.Top = pCompras.Top_Aux;
            return View(roles);
        }

        // GET: DetalleCompraController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var compras = await detallecompraBL.ObtenerPorIdAsync(new DetalleCompra { IdCompras = id });
            return View(compras);
        }

        // GET: DetalleCompraController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: DetalleCompraController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DetalleCompra pCompras)
        {
            try
            {
                int result = await detallecompraBL.CrearAsync(pCompras);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCompras);
            }
        }


        // GET: DetalleCompraController/Edit/5
        public async Task<IActionResult> Edit(DetalleCompra pCompras)
        {
            var compras = await detallecompraBL.ObtenerPorIdAsync(pCompras);
            ViewBag.Error = "";
            return View(compras);
        }

        // POST: DetalleCompraController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DetalleCompra pCompras)
        {
            try
            {
                int result = await detallecompraBL.ModificarAsync(pCompras);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCompras);
            }
        }

        // GET: DetalleCompraController/Delete/5
        public async Task<IActionResult> Delete(DetalleCompra pCompras)
        {
            ViewBag.Error = "";
            var compra = await detallecompraBL.ObtenerPorIdAsync(pCompras);
            return View(compra);
        }

        // POST: DetalleCompraController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, DetalleCompra pCompras)
        {
            try
            {
                int result = await detallecompraBL.EliminarAsync(pCompras);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCompras);
            }
        }
    }
}
