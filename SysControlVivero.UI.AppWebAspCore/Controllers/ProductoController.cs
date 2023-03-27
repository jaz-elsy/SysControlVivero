using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysControlVivero.EntidadesDeNegocio;
using SysControlVivero.LogicaDeNegocio;

namespace SysControlVivero.UI.AppWebAspCore.Controllers
{
    //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ProductoController : Controller
    {
        ProductoBL _productoBL = new ProductoBL();
        // GET: ProductoController
        public async Task<IActionResult> Index(Producto pProducto = null)
        {
            if (pProducto == null)
                pProducto = new Producto();
            if (pProducto.Top_Aux == 0)
                pProducto.Top_Aux = 10;
            else if (pProducto.Top_Aux == -1)
                pProducto.Top_Aux = 0;
            var productos = await _productoBL.BuscarAsync(pProducto);
            ViewBag.Top = pProducto.Top_Aux;
            return View(productos);
        }

        // GET: RolController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var producto = await _productoBL.ObtenerPorIdAsync(new Producto { IdProducto = id });
            return View(producto);
        }

        // GET: RolController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: RolController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto pProducto)
        {
            try
            {
                int result = await _productoBL.CrearAsync(pProducto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pProducto);
            }
        }

        // GET: RolController/Edit/5
        public async Task<IActionResult> Edit(Producto pProducto)
        {
            var producto = await _productoBL.ObtenerPorIdAsync(pProducto);
            ViewBag.Error = "";
            return View(producto);
        }

        // POST: RolController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto pProducto)
        {
            try
            {
                int result = await _productoBL.ModificarAsync(pProducto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pProducto);
            }
        }

        // GET: RolController/Delete/5
        public async Task<IActionResult> Delete(Producto pProducto)
        {
            ViewBag.Error = "";
            var producto = await _productoBL.ObtenerPorIdAsync(pProducto);
            return View(producto);
        }

        // POST: RolController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Producto pProducto)
        {
            try
            {
                int result = await _productoBL.EliminarAsync(pProducto);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pProducto);
            }
        }
    }
}
