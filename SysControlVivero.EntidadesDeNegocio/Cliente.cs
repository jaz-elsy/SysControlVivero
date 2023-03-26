using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.EntidadesDeNegocio
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [NotMapped]
        public int Top_Aux { get; set; }

        public List<Factura> facturas { get; set; }

        public static implicit operator Cliente(Rol v)
        {
            throw new NotImplementedException();
        }
    }
}
