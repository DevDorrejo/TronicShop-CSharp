using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronicShop.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }

        // Relaciones (opcional si necesitas usarlas en lógica)
        public string? ClienteNombre { get; set; }
        public string? UsuarioNombre { get; set; }
        public List<DetalleVenta> Detalles { get; set; } = new();

    }
}
