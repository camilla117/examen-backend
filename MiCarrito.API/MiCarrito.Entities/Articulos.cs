using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCarrito.Entities
{
    public class Articulos
    {
        public Guid Id { get; set; }
        public required string Nombre { get; set; }
        public required string Descripcion { get; set; }
        public double Precio { get; set; }
        public required string Imagen { get; set; }
        public int Stock {  get; set; }
    }
}
