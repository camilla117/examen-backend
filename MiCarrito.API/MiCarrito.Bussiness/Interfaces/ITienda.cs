using MiCarrito.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCarrito.Bussiness.Interfaces
{
    public interface ITienda
    {
        Task<Tienda?> FindAsync(Guid id);
        IEnumerable<Tienda> FindAllAsync();
        Task AddAsync(Tienda articulo);
        Task<bool> UpdateAsync(Tienda articulo);
        Task<bool> DeleteAsync(Guid id);
    }
}
