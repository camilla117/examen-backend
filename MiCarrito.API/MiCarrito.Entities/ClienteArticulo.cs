using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCarrito.Entities
{
    public class ClienteArticulo
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public virtual Clientes? Cliente { get; set; }
        public Guid ArticuloId { get; set; }
        public virtual Articulos? Articulo { get; set; }
        public DateTime Fecha { get; set; }
    }
}
