using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronicShop.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Teléfono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Dirección { get; set; } = string.Empty;
        public string? Identificación { get; set; } = string.Empty;
        public bool Estado { get; set; }
        public DateTime FechaCreado { get; set; }
    }
}
