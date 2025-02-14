using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCarrito.Entities
{
    public class ArticuloTienda
    {   public Guid Id {  get; set; }
        public Guid ArticuloId { get; set; }
        public virtual Articulos? Articulo { get; set; }
        public Guid TiendaId { get; set; }
        public virtual Tienda? Tienda { get; set; }
        public DateTime Fecha { get; set; }
    }
}
