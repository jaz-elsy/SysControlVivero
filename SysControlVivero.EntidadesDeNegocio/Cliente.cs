using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.EntidadesDeNegocio
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }

        [Required]
        [StringLength(10,ErrorMessage = "Maximo 10 caracteres", MinimumLength =10)]
        public string DUI { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "Maximo 9 caracteres")]
        public string Telefono { get; set; }

        //public List<Factura> facturas { get; set; }
    }
}
