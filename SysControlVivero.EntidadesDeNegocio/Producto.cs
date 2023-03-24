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
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "Codigo de producto es obligatorio")]
        [Display(Name = "Codigo de Producto")]
        public int CodProducto { get; set; }

        [Required(ErrorMessage = "Nombre de producto es obligatorio")]
        [StringLength(50)]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Descripcion de producto es obligatorio")]
        [StringLength(50)]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Fecha de vencimiento es obligatorio")]
        [Display(Name = "Fecha de vencimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime FechaVencimiento { get; set; }

        [Required(ErrorMessage = "Precio de producto es obligatorio")]
        [RegularExpression(@"^\d{0,8}(\.\d{1,2})?$")]
        public decimal Precio { get; set; }

        [NotMapped]
        public int Top_Aux { get; set; }


        //public Categoria? categoria { get; set; }
        //public DetalleDeCompra? detalledecompra { get; set; }
        //public Inventario? inventario { get; set; }
        //public DetalleDeVenta? detalledeventa { get; set; }

    }
}
