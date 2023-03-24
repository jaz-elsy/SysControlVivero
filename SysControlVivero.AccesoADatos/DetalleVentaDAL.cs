using Microsoft.EntityFrameworkCore;
using SysControlVivero.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.AccesoADatos
{
    public class DetalleVentaDAL
    {
        public static async Task<int> CrearAsync(DetalleVenta pDetalleVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pDetalleVenta);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(DetalleVenta pDetalleVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var detalleventa = await bdContexto.DetalleVenta.FirstOrDefaultAsync(s => s.IdDetalleVenta == pDetalleVenta.IdDetalleVenta);
                detalleventa.IdDetalleVenta = pDetalleVenta.IdDetalleVenta;

                bdContexto.Update(detalleventa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(DetalleVenta pDetalleVenta)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var detalleventa = await bdContexto.DetalleVenta.FirstOrDefaultAsync(s => s.IdDetalleVenta == pDetalleVenta.IdDetalleVenta);
                bdContexto.DetalleVenta.Remove(detalleventa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<DetalleVenta> ObtenerPorIdAsync(DetalleVenta pDetalleVenta)
        {
            var detalleventa = new DetalleVenta();
            using (var bdContexto = new BDContexto())
            {
                detalleventa = await bdContexto.DetalleVenta.FirstOrDefaultAsync(s => s.IdDetalleVenta == pDetalleVenta.IdDetalleVenta);
            }
            return detalleventa;
        }
        public static async Task<List<DetalleVenta>> ObtenerTodosAsync()
        {
            var detalleventas = new List<DetalleVenta>();
            using (var bdContexto = new BDContexto())
            {
                detalleventas = await bdContexto.DetalleVenta.ToListAsync();
            }
            return detalleventas;
        }
        internal static IQueryable<DetalleVenta> QuerySelect(IQueryable<DetalleVenta> pQuery, DetalleVenta pDetalleVenta)
        {
            //Si es entero o decimal va asi
            if (pDetalleVenta.IdDetalleVenta > 0)
                pQuery = pQuery.Where(s => s.IdDetalleVenta == pDetalleVenta.IdDetalleVenta);

            if (pDetalleVenta.Cantidad > 0)
                pQuery = pQuery.Where(s => s.Cantidad == pDetalleVenta.Cantidad);
            if (pDetalleVenta.IdDetalleVenta > 0)
                pQuery = pQuery.Where(s => s.VentaNoSujeta == pDetalleVenta.VentaNoSujeta);
            if (pDetalleVenta.IdDetalleVenta > 0)
                pQuery = pQuery.Where(s => s.VentaExenta == pDetalleVenta.VentaExenta);



            //Si es de tipo estring va asi
            if (!string.IsNullOrWhiteSpace(pDetalleVenta.FormaDePago))
                pQuery = pQuery.Where(s => s.FormaDePago.Contains(pDetalleVenta.FormaDePago));

            if (pDetalleVenta.Descuento > 0)
                pQuery = pQuery.Where(s => s.Descuento == pDetalleVenta.Descuento);


            pQuery = pQuery.OrderByDescending(s => s.IdDetalleVenta).AsQueryable();
            if (pDetalleVenta.Top_Aux > 0)
                pQuery = pQuery.Take(pDetalleVenta.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<DetalleVenta>> BuscarAsync(DetalleVenta pDetalleVenta)
        {
            var detalleventas = new List<DetalleVenta>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.DetalleVenta.AsQueryable();
                select = QuerySelect(select, pDetalleVenta);
                detalleventas = await select.ToListAsync();
            }
            return detalleventas;
        }

    }
}
