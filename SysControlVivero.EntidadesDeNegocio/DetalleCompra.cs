using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.EntidadesDeNegocio
{
    public class DetalleCompra
    {
        [Key]
        public int IdCompras { get; set; }

        [Display(Name = "Fecha registro")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string NombreEmpresa { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Descripcion { get; set; }

        [Required]
        public decimal PrecioTotal { get; set; }

        //public List<Producto> productos { get; set; }
    }
}
