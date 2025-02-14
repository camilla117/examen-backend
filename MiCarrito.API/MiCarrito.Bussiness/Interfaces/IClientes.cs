using MiCarrito.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCarrito.Bussiness.Interfaces
{
    public interface IClientes
    {
        Task<Clientes?> Login(string username, string password);
        Task<Clientes?> FindAsync(Guid id);
        IEnumerable<Clientes> FindAllAsync();
        Task AddAsync(Clientes articulo);
        Task<bool> UpdateAsync(Clientes articulo);
        Task<bool> DeleteAsync(Guid id);
    }
}
