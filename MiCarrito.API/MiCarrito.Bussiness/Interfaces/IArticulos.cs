using MiCarrito.Entities;

namespace MiCarrito.Bussiness.Interfaces
{
    public interface IArticulos
    {
        Task<Articulos?> FindAsync(Guid id);
        IEnumerable<Articulos> FindAllAsync(Guid id);
        Task AddAsync (Articulos articulo);
        Task<bool> UpdateAsync(Articulos articulo);
        Task<bool> DeleteAsync(Guid id);
    }
}
