using MiCarrito.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCarrito.Bussiness.Interfaces
{
    public interface IClienteArticulo
    {
        Task<ClienteArticulo?> FindAsync(Guid id);
        IEnumerable<ClienteArticulo> FindAllAsync();
        Task AddAsync(ClienteArticulo articulo);
        Task<bool> UpdateAsync(ClienteArticulo articulo);
        Task<bool> DeleteAsync(Guid id);
    }
}
