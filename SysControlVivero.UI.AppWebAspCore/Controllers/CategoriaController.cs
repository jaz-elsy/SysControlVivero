using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using SysControlVivero.LogicaDeNegocio;
using SysControlVivero.EntidadesDeNegocio;
using SysControlVivero.AccesoADatos;

namespace SysControlVivero.UI.AppWebAspCore.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class CategoriaController : Controller
    {
        CategoriaBL categoriaBL = new CategoriaBL();
        //GET CategoriaController
        public async Task<IActionResult> Index(Categoria pCategoria = null)
        {
            if (pCategoria == null)
                pCategoria = new Categoria();
            if (pCategoria.Top_Aux == 0)
                pCategoria.Top_Aux = 10;
            else if (pCategoria.Top_Aux == -1)
                pCategoria.Top_Aux = 0;
            var categorias = await categoriaBL.BuscarAsync(pCategoria);
            ViewBag.Top = pCategoria.Top_Aux;
            return View(categorias);
        }

        // GET: CategoriaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var categoria = await categoriaBL.ObtenerPorIdAsync(new Categoria { IdCategoria = id });
            return View(categoria);
        }

        //GET: CategoriaController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        //POST: CategoriaContoller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Categoria pCategoria)
        {
            try
            {
                int result = await categoriaBL.CrearAsync(pCategoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCategoria);
            }
        }

        // GET: CategoriaController/Edit/5
        public async Task<IActionResult> Edit(Categoria pCategoria)
        {
            var categoria = await categoriaBL.ObtenerPorIdAsync(pCategoria);
            ViewBag.Error = "";
            return View(categoria);
        }

        // POST: CategoriaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Categoria pCategoria)
        {
            try
            {
                int result = await categoriaBL.ModificarAsync(pCategoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCategoria);
            }
        }

        // GET: CategoriaController/Delete/5
        public async Task<IActionResult> Delete(Categoria pCategoria)
        {
            ViewBag.Error = "";
            var categoria = await categoriaBL.ObtenerPorIdAsync(pCategoria);
            return View(categoria);
        }

        // POST: CategoriaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Categoria pCategoria)
        {
            try
            {
                int result = await categoriaBL.EliminarAsync(pCategoria);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pCategoria);
            }
        }
    }
}
