using SysControlVivero.AccesoADatos;
using SysControlVivero.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.LogicaDeNegocio
{
    public class DetalleCompraBL
    {
        public async Task<int> CrearAsync(DetalleCompra pCompras)
        {
            return await DetalleCompraDAL.CrearAsync(pCompras);
        }
        public async Task<int> ModificarAsync(DetalleCompra pCompras)
        {
            return await DetalleCompraDAL.ModificarAsync(pCompras);
        }
        public async Task<int> EliminarAsync(DetalleCompra pCompras)
        {
            return await DetalleCompraDAL.EliminarAsync(pCompras);
        }
        public async Task<DetalleCompra> ObtenerPorIdAsync(DetalleCompra pCompras)
        {
            return await DetalleCompraDAL.ObtenerPorIdAsync(pCompras);
        }
        public async Task<List<DetalleCompra>> ObtenerTodosAsync()
        {
            return await DetalleCompraDAL.ObtenerTodosAsync();
        }
        public async Task<List<DetalleCompra>> BuscarAsync(DetalleCompra pCompras)
        {
            return await DetalleCompraDAL.BuscarAsync(pCompras);
        }
    }
}
