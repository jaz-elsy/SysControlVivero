using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysControlVivero.EntidadesDeNegocio
{
    public class Factura
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdFactura { get; set; }

        [Required]

        public int NFactura { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime Fecha { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximo 50 caracteres")]
        public string Direccion { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "Maximo 9 caracteres")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Maximo 10 caracteres")]
        public string DUI { get; set; }

        [Required]
        [RegularExpression(@"^\d{0,8}(\.\d{1,2})?$")]
        public decimal Sumas { get; set; }

        [Required]
        [RegularExpression(@"^\d{0,8}(\.\d{1,2})?$")]
        public decimal VentaTotal { get; set; }
        [NotMapped]
        public int Top_Aux { get; set; }

        public List<DetalleVenta>? detalleventas { get; set; }

    }
}
