using Microsoft.EntityFrameworkCore;
using SysControlVivero.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.AccesoADatos
{
    public class InventarioDAL
    {
        public static async Task<int> CrearAsync(Inventario pInventario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pInventario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Inventario pInventario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var inventario = await bdContexto.Inventario.FirstOrDefaultAsync(s => s.IdInventario == pInventario.IdInventario);
                //inventario.Nombre = pInventario.Nombre;
                bdContexto.Update(inventario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Inventario pInventario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var inventario = await bdContexto.Inventario.FirstOrDefaultAsync(s => s.IdInventario == pInventario.IdInventario);
                bdContexto.Inventario.Remove(inventario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Inventario> ObtenerPorIdAsync(Inventario pInventario)
        {
            var inventario = new Inventario();
            using (var bdContexto = new BDContexto())
            {
                inventario = await bdContexto.Inventario.FirstOrDefaultAsync(s => s.IdInventario == pInventario.IdInventario);
            }
            return inventario;
        }
        public static async Task<List<Inventario>> ObtenerTodosAsync()
        {
            var inventarios = new List<Inventario>();
            using (var bdContexto = new BDContexto())
            {
                inventarios = await bdContexto.Inventario.ToListAsync();
            }
            return inventarios;
        }
        internal static IQueryable<Inventario> QuerySelect(IQueryable<Inventario> pQuery, Inventario pInventario)
        {
            if (pInventario.IdInventario > 0)
                pQuery = pQuery.Where(s => s.IdInventario == pInventario.IdInventario);
            // if (!string.IsNullOrWhiteSpace(pInventario.Nombre))
            // pQuery = pQuery.Where(s => s.Nombre.Contains(Inventario.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.IdInventario).AsQueryable();
            if (pInventario.Top_Aux > 0)
                pQuery = pQuery.Take(pInventario.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Inventario>> BuscarAsync(Inventario pInventario)
        {
            var inventarios = new List<Inventario>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Inventario.AsQueryable();
                select = QuerySelect(select, pInventario);
                inventarios = await select.ToListAsync();
            }
            return inventarios;


        }
    }
}
