using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCarrito.Entities
{
    public class Clientes
    {
        public Guid Id {  get; set; }
        public required string Nombre { get; set; }
        public required string Apellidos { get; set; }
        public required string Usuario { get; set; }
        public required string Password { get; set; }
        public required string Direccion { get; set; }
    }
}
