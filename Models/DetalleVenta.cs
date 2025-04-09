using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronicShop.Models
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int IdVenta { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal TotalLinea { get; set; }

        // Relación para mostrar nombre del producto (opcional)
        public string? ProductoNombre { get; set; }
    }
}
