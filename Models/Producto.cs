using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronicShop.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string CódigoBarra { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Descripción { get; set; } = "";
        public string Categoría { get; set; } = "";
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool Estado { get; set; } = true;
        public int? IdProveedor { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime FechaActualizado { get; set; }

        public string? NombreProveedor { get; set; }

    }
}
