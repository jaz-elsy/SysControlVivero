using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysControlVivero.EntidadesDeNegocio;
using SysControlVivero.LogicaDeNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace SysControlVivero.UI.AppWebAspCore.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class FacturaController : Controller
    {

        FacturaBL _facturaBL = new FacturaBL();

        // GET: FacturaController
        public async Task<IActionResult> Index(Factura pFactura = null)
        {
            if (pFactura == null)
                pFactura = new Factura();
            if (pFactura.Top_Aux == 0)
                pFactura.Top_Aux = 10;
            else if (pFactura.Top_Aux == -1)
                pFactura.Top_Aux = 0;
            var facturas = await _facturaBL.BuscarAsync(pFactura);
            ViewBag.Top = pFactura.Top_Aux;
            return View(facturas);


        }


        // GET: FacturaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var factura = await _facturaBL.ObtenerPorIdAsync(new Factura { IdFactura = id });
            return View(factura);
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

        public async Task<IActionResult> Create(Factura pFactura)
        {
            try
            {
                int result = await _facturaBL.CrearAsync(pFactura);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pFactura);
            }
        }


        // GET: FacturaController/Edit/5
        public async Task<IActionResult> Edit(Factura pFactura)
        {


            var factura = await _facturaBL.ObtenerPorIdAsync(pFactura);
            ViewBag.Error = "";

            return View(factura);

        }
        // POST: FacturaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Factura pFactura)
        {
            try
            {
                int result = await _facturaBL.ModificarAsync(pFactura);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pFactura);

            }
        }

        // GET: FacturaController/Delete/5
        public async Task<IActionResult> Delete(Factura pFactura)
        {
            ViewBag.Error = "";
            var factura = await _facturaBL.ObtenerPorIdAsync(pFactura);
            return View(factura);
        }
      
        // POST: FacturaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Factura pFactura)
        {
            try
            {
                int result = await _facturaBL.EliminarAsync(pFactura);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(pFactura);
            }
        }
    }
}

    

