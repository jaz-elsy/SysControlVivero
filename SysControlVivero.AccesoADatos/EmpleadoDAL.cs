using Microsoft.EntityFrameworkCore;
using SysControlVivero.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.AccesoADatos
{
    public class EmpleadoDAL
    {
            public static async Task<int> CrearAsync(Empleado pempleado)
            {
                int result = 0;
                using (var bdContexto = new BDContexto())
                {
                    bdContexto.Add(pempleado);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
            public static async Task<int> ModificarAsync(Empleado pempleado)
            {
                int result = 0;
                using (var bdContexto = new BDContexto())
                {
                    var empleado = await bdContexto.Empleado.FirstOrDefaultAsync(s => s.IdEmpleado == pempleado.IdEmpleado);
                    empleado.Nombre = pempleado.Nombre;
                    bdContexto.Update(empleado);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
            public static async Task<int> EliminarAsync(Empleado pempleado)
            {
                int result = 0;
                using (var bdContexto = new BDContexto())
                {
                    var empleado = await bdContexto.Empleado.FirstOrDefaultAsync(s => s.IdEmpleado == pempleado.IdEmpleado);
                    bdContexto.Empleado.Remove(empleado);
                    result = await bdContexto.SaveChangesAsync();
                }
                return result;
            }
            public static async Task<Empleado> ObtenerPorIdAsync(Empleado pempleado)
            {
                var Empleado = new Empleado();
                using (var bdContexto = new BDContexto())
                {
                    Empleado = await bdContexto.Empleado.FirstOrDefaultAsync(s => s.IdEmpleado == pempleado.IdEmpleado);
                }
                return Empleado;
            }
            public static async Task<List<Empleado>> ObtenerTodosAsync()
            {
                var empleados = new List<Empleado>();
                using (var bdContexto = new BDContexto())
                {
                    empleados = await bdContexto.Empleado.ToListAsync();
                }
                return empleados;
            }
            internal static IQueryable<Empleado> QuerySelect(IQueryable<Empleado> pQuery, Empleado pempleado)
            {
                if (pempleado.IdEmpleado > 0)
                    pQuery = pQuery.Where(s => s.IdEmpleado == pempleado.IdEmpleado);
                if (!string.IsNullOrWhiteSpace(pempleado.Nombre))
                    pQuery = pQuery.Where(s => s.Nombre.Contains(pempleado.Nombre));
                pQuery = pQuery.OrderByDescending(s => s.IdEmpleado).AsQueryable();
                if (pempleado.Top_Aux > 0)
                    pQuery = pQuery.Take(pempleado.Top_Aux).AsQueryable();
                return pQuery;
            }
            public static async Task<List<Empleado>> BuscarAsync(Empleado pempleado)
            {
                var empleados = new List<Empleado>();
                using (var bdContexto = new BDContexto())
                {
                    var select = bdContexto.Empleado.AsQueryable();
                    select = QuerySelect(select, pempleado);
                    empleados = await select.ToListAsync();
                }
                return empleados;
            }
        }
}
