using Microsoft.EntityFrameworkCore;
using SysControlVivero.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.AccesoADatos
{
    public class FacturaDAL
    {
        public static async Task<int> CrearAsync(Factura pFactura)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pFactura);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Factura pFactura)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var factura = await bdContexto.Factura.FirstOrDefaultAsync(s => s.IdFactura == pFactura.IdFactura);
                factura.NFactura = pFactura.NFactura;
                bdContexto.Update(factura);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Factura pFactura)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var factura = await bdContexto.Factura.FirstOrDefaultAsync(s => s.IdFactura == pFactura.IdFactura);
                bdContexto.Factura.Remove(factura);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Factura> ObtenerPorIdAsync(Factura pFactura)
        {
            var factura = new Factura();
            using (var bdContexto = new BDContexto())
            {
                factura = await bdContexto.Factura.FirstOrDefaultAsync(s => s.IdFactura == pFactura.IdFactura);
            }
            return factura;
        }
        public static async Task<List<Factura>> ObtenerTodosAsync()
        {
            var factura = new List<Factura>();
            using (var bdContexto = new BDContexto())
            {
                factura = await bdContexto.Factura.ToListAsync();
            }
            return factura;
        }
        internal static IQueryable<Factura> QuerySelect(IQueryable<Factura> pQuery, Factura pFactura)
        {
            //Si es entero o decimal va asi
            if (pFactura.IdFactura > 0)
                pQuery = pQuery.Where(s => s.IdFactura == pFactura.IdFactura);

            if (pFactura.NFactura > 0)
                pQuery = pQuery.Where(s => s.NFactura == pFactura.NFactura);

            if (pFactura.Sumas > 0)
                pQuery = pQuery.Where(s => s.Sumas == pFactura.Sumas);

            if (pFactura.VentaTotal > 0)
                pQuery = pQuery.Where(s => s.VentaTotal == pFactura.VentaTotal);


            // si es string va asi 
            // tipo fecha .ToString()

            if (!string.IsNullOrWhiteSpace(pFactura.Fecha.ToString()))
                pQuery = pQuery.Where(s => s.Fecha.ToString().Contains(pFactura.Fecha.ToString()));

            if (!string.IsNullOrWhiteSpace(pFactura.Direccion))
                pQuery = pQuery.Where(s => s.Direccion.Contains(pFactura.Direccion));


            if (!string.IsNullOrWhiteSpace(pFactura.Telefono))
                pQuery = pQuery.Where(s => s.Telefono.Contains(pFactura.Telefono));

            if (!string.IsNullOrWhiteSpace(pFactura.DUI))
                pQuery = pQuery.Where(s => s.DUI.Contains(pFactura.DUI));



            pQuery = pQuery.OrderByDescending(s => s.IdFactura).AsQueryable();

            if (pFactura.Top_Aux > 0)
                pQuery = pQuery.Take(pFactura.Top_Aux).AsQueryable();
            return pQuery;

        }
        public static async Task<List<Factura>> BuscarAsync(Factura pFactura)
        {
            var facturas = new List<Factura>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Factura.AsQueryable();
                select = QuerySelect(select, pFactura);
                facturas = await select.ToListAsync();
            }
            return facturas;
        }
    }
}
