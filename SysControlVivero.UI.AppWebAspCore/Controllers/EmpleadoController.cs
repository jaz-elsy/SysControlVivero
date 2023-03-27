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
    public class EmpleadoController : Controller
    {
        EmpleadoBL empleadoBL = new EmpleadoBL();
        // GET: EmpleadoController
        public async Task<IActionResult> Index(Empleado pEmpleado = null)
        {
            if (pEmpleado == null)
                pEmpleado = new Empleado();
            if (pEmpleado.Top_Aux == 0)
                pEmpleado.Top_Aux = 10;
            else if (pEmpleado.Top_Aux == -1)
                pEmpleado.Top_Aux = 0;
            var roles = await empleadoBL.BuscarAsync(pEmpleado);
            ViewBag.Top = pEmpleado.Top_Aux;
            return View(roles);
        }

        // GET: EmpleadoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var empleado = await empleadoBL.ObtenerPorIdAsync(new Empleado { IdEmpleado = id });
            return View(empleado);
        }

        // GET: EmpleadoController/Create
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: EmpleadoContoller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Empleado pEmpleado)
        {
            try
            {
                int result = await empleadoBL.CrearAsync(pEmpleado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pEmpleado);
            }
        }

        // GET: EmpleadoController/Edit/5
        public async Task<IActionResult> Edit(Empleado pEmpleado)
        {
            var empleado = await empleadoBL.ObtenerPorIdAsync(pEmpleado);
            ViewBag.Error = "";
            return View(empleado);
        }

        // POST: EmpleadoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Empleado pEmpleado)
        {
            try
            {
                int result = await empleadoBL.ModificarAsync(pEmpleado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pEmpleado);
            }
        }

        // GET: EmpleadoController/Delete/5
        public async Task<IActionResult> Delete(Empleado pEmpleado)
        {
            ViewBag.Error = "";
            var empleado = await empleadoBL.ObtenerPorIdAsync(pEmpleado);
            return View(empleado);
        }

        // POST: EmpleadoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Empleado pEmpleado)
        {
            try
            {
                int result = await empleadoBL.EliminarAsync(pEmpleado);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pEmpleado);
            }
        }
    }
}
