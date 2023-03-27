using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysControlVivero.AccesoADatos;
using SysControlVivero.EntidadesDeNegocio;
using SysControlVivero.LogicaDeNegocio;

namespace SysControlVivero.UI.AppWebAspCore.Controllers
{
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class InventarioController : Controller
    {
        InventarioBL _InventarioBL = new InventarioBL();
        // GET: InventarioController
        public async Task<IActionResult> Index(Inventario pInventario = null)
        {
            if (pInventario == null)
                pInventario = new Inventario();
            if (pInventario.Top_Aux == 0)
                pInventario.Top_Aux = 10;
            else if (pInventario.Top_Aux == -1)
                pInventario.Top_Aux = 0;
            var inventarios = await _InventarioBL.BuscarAsync(pInventario);
            ViewBag.Top = pInventario.Top_Aux;
            return View(inventarios);
        }

        // GET: InventarioController/Details/5
        public async Task<IActionResult> Details(int idinventario)
        {
            var inventario = await _InventarioBL.ObtenerPorIdAsync(new Inventario { IdInventario = idinventario});
            return View(inventario);
        }

        // GET: InventarioController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }


        // POST: InventarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inventario pInventario)
        {
            try
            {
                int result = await _InventarioBL.CrearAsync(pInventario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pInventario);
            }
        }

        // GET: InventarioController/Edit/5
        public async Task<IActionResult> Edit(Inventario pInventario)
        {
            var inventario = await _InventarioBL.ObtenerPorIdAsync(pInventario);
            ViewBag.Error = "";
            return View(inventario);
        }

        // POST: RolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Inventario pInventario)
        {
            try
            {
                int result = await _InventarioBL.ModificarAsync(pInventario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pInventario);
            }
        }

        // GET: RolController/Delete/5
        public async Task<IActionResult> Delete(Inventario pInventario)
        {
            ViewBag.Error = "";
            var inventario = await _InventarioBL.ObtenerPorIdAsync(pInventario);
            return View(inventario);
        }

        // POST: RolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Inventario pInventario)
        {
            try
            {
                int result = await _InventarioBL.EliminarAsync(pInventario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pInventario);
            }
        }
    }
}
