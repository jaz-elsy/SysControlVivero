using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.EntidadesDeNegocio
{
    public class DetalleVenta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdDetalleVenta { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [RegularExpression(@"^\d{0,8}(\.\d{1,2})?$")]
        public decimal Descuento { get; set; }

        [Required]
        public string FormaDePago { get; set; }

        [Required]
        [RegularExpression(@"^\d{0,8}(\.\d{1,2})?$")]
        public decimal VentaNoSujeta { get; set; }

        [Required]
        [RegularExpression(@"^\d{0,8}(\.\d{1,2})?$")]
        public decimal VentaExenta { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }

        public List<Producto> productos { get; set; }

    }
}
