using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronicShop.Models
{
    internal class Proveedor
    {
        public int Id { get; set; }
        public string Compañía { get; set; } = "";
        public string NombreContacto { get; set; } = "";
        public string Teléfono { get; set; } = "";
        public string Teléfono2 { get; set; } = "";
        public string Whatsapp { get; set; } = "";
        public string Correo { get; set; } = "";
        public string Dirección { get; set; } = "";
        public string RNC { get; set; } = "";
        public bool Estado { get; set; } = true;
        public DateTime FechaCreado { get; set; }
        public DateTime FechaActualizado { get; set; }
    }
}
