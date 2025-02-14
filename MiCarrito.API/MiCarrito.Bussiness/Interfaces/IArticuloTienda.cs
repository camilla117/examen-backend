using MiCarrito.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCarrito.Bussiness.Interfaces
{
    public interface IArticuloTienda
    {
        Task<ArticuloTienda?> FindAsync(Guid id);
        IEnumerable<ArticuloTienda> FindAllAsync();
        Task AddAsync(ArticuloTienda articulo);
        Task<bool> UpdateAsync(ArticuloTienda articulo);
        Task<bool> DeleteAsync(Guid id, Guid idTienda);
    }
}
