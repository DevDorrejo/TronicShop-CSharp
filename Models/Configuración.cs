using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TronicShop.Models
{
    internal class Configuración
    {
        public int Id { get; set; }
        public string NombreEmpresa { get; set; } = "";
        public string? RNC { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public decimal Impuesto { get; set; }
        public byte[]? Logo { get; set; }
        public DateTime FechaCreado { get; set; }
        public DateTime? FechaActualizado { get; set; }
    }
}
