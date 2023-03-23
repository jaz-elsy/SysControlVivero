using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SysControlVivero.EntidadesDeNegocio;

namespace SysControlVivero.AccesoADatos
{
    public class RolDAL
    {
        /*public static async Task<int> CrearAsync(Cliente pRol)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pRol);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Cliente pRol)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var rol = await bdContexto.Rol.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
                rol.Nombre = pRol.Nombre;
                bdContexto.Update(rol);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Cliente pRol)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var rol = await bdContexto.Rol.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
                bdContexto.Rol.Remove(rol);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Cliente> ObtenerPorIdAsync(Cliente pRol)
        {
            var rol = new Cliente();
            using (var bdContexto = new BDContexto())
            {
                rol = await bdContexto.Rol.FirstOrDefaultAsync(s => s.IdRol == pRol.IdRol);
            }
            return rol;
        }
        public static async Task<List<Cliente>> ObtenerTodosAsync()
        {
            var roles = new List<Cliente>();
            using (var bdContexto = new BDContexto())
            {
                roles = await bdContexto.Rol.ToListAsync();
            }
            return roles;
        }
        internal static IQueryable<Cliente> QuerySelect(IQueryable<Cliente> pQuery, Cliente pRol)
        {
            if (pRol.IdRol > 0)
                pQuery = pQuery.Where(s => s.IdRol == pRol.IdRol);
            if (!string.IsNullOrWhiteSpace(pRol.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pRol.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.IdRol).AsQueryable();
            if (pRol.Top_Aux > 0)
                pQuery = pQuery.Take(pRol.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Cliente>> BuscarAsync(Cliente pRol)
        {
            var roles = new List<Cliente>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Rol.AsQueryable();
                select = QuerySelect(select, pRol);
                roles = await select.ToListAsync();
            }
            return roles;
        }*/
    }
}
