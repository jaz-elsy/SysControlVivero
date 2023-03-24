using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.EntidadesDeNegocio
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Correo { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string DUI { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Direccion { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Cargo { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }

        //public List<Factura> facturas { get; set; }
        public Usuario? usuario { get; set; }
    }
}
