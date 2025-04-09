using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronicShop.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public byte[] Contraseña { get; set; } = Array.Empty<byte>();
        public string Rol { get; set; } = "vendedor";
        public bool Estado { get; set; } = true;
        public DateTime FechaCreado { get; set; } = DateTime.Now;
    }
}
