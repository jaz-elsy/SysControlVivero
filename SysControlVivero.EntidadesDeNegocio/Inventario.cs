using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SysControlVivero.EntidadesDeNegocio
{
    public class Inventario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdInventario { get; set; }

        [Required(ErrorMessage = "codigo de producto es obligatorio")]
        [Display(Name = "Codigo de Producto")]
        public int CodProducto { get; set; }

        [Required(ErrorMessage = "descripción de producto es obligatorio")]
        [StringLength(50, ErrorMessage = "maximo 50 caracteres")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Existencias mes anterior es obligatorio")]
        [Display(Name = "Existencias mes anterior")]
        public int ExistenciasMesAnterior { get; set; }

        [Required(ErrorMessage = "Entradas es obligatorio")]
        public int Entradas { get; set; }

        [Required(ErrorMessage = "Salidas es obligatorio")]
        public int Salidas { get; set; }

        [Required(ErrorMessage = "Stock es obligatorio")]
        public int Stock { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }

        //public List<Producto>? productos { get; set; }

    }
}
