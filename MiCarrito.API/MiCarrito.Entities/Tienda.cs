using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCarrito.Entities
{
    public class Tienda
    {
        public Guid Id { get; set; }
        public required string Sucursal {  get; set; }
        public required string Direccion { get; set; }
    }
}
