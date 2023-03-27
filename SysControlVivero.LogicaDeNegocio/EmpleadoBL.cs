using SysControlVivero.AccesoADatos;
using SysControlVivero.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.LogicaDeNegocio
{
    public class EmpleadoBL
    {
        public async Task<int> CrearAsync(Empleado pempleado)
        {
            return await EmpleadoDAL.CrearAsync(pempleado);
        }
        public async Task<int> ModificarAsync(Empleado pempleado)
        {
            return await EmpleadoDAL.ModificarAsync(pempleado);
        }
        public async Task<int> EliminarAsync(Empleado pempleado)
        {
            return await EmpleadoDAL.EliminarAsync(pempleado);
        }
        public async Task<Empleado> ObtenerPorIdAsync(Empleado pempleado)
        {
            return await EmpleadoDAL.ObtenerPorIdAsync(pempleado);
        }
        public async Task<List<Empleado>> ObtenerTodosAsync()
        {
            return await EmpleadoDAL.ObtenerTodosAsync();
        }
        public async Task<List<Empleado>> BuscarAsync(Empleado pEmpleado)
        {
            return await EmpleadoDAL.BuscarAsync(pEmpleado);
        }
    }
}
