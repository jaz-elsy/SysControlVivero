using SysControlVivero.AccesoADatos;
using SysControlVivero.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.LogicaDeNegocio
{
    public class ClienteBL
    {
        public async Task<int> CrearAsync(Cliente pCliente)
        {
            return await ClienteDAL.CrearAsync(pCliente);
        }
        public async Task<int> ModificarAsync(Cliente pCliente)
        {
            return await ClienteDAL.ModificarAsync(pCliente);
        }
        public async Task<int> EliminarAsync(Cliente pCliente)
        {
            return await ClienteDAL.EliminarAsync(pCliente);
        }
        public async Task<Cliente> ObtenerPorIdAsync(Cliente pRol)
        {
            return await ClienteDAL.ObtenerPorIdAsync(pRol);
        }
        public async Task<List<Cliente>> ObtenerTodosAsync()
        {
            return await ClienteDAL.ObtenerTodosAsync();
        }
        public async Task<List<Cliente>> BuscarAsync(Cliente pRol)
        {
            return await ClienteDAL.BuscarAsync(pRol);
        }
    }
}
