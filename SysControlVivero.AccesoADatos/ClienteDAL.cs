using Microsoft.EntityFrameworkCore;
using SysControlVivero.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.AccesoADatos
{
    public class ClienteDAL
    {
        public static async Task<int> CrearAsync(Cliente pCliente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pCliente);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Cliente pCliente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var cliente = await bdContexto.Cliente.FirstOrDefaultAsync(s => s.IdCliente == pCliente.IdCliente);
                cliente.Nombre = pCliente.Nombre;
                bdContexto.Update(cliente);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Cliente pCliente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var cliente = await bdContexto.Cliente.FirstOrDefaultAsync(s => s.IdCliente == pCliente.IdCliente);
                bdContexto.Cliente.Remove(cliente);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Cliente> ObtenerPorIdAsync(Cliente pCliente)
        {
            var cliente = new Cliente();
            using (var bdContexto = new BDContexto())
            {
                cliente = await bdContexto.Rol.FirstOrDefaultAsync(s => s.Id == pCliente.Id);
            }
            return cliente;
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
    }
}
