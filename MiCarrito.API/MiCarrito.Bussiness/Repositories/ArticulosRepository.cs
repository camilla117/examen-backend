using MiCarrito.Bussiness.Interfaces;
using MiCarrito.Data;
using Microsoft.EntityFrameworkCore;
using MiCarrito.Entities;

namespace MiCarrito.Bussiness.Repositories
{
    public class ArticulosRepository(CarritoDbContext db) : IArticulos
    {
        private readonly CarritoDbContext _db = db;
        public async Task AddAsync(Articulos articulo)
        {
            _db.Articulos.Add(articulo);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var affected = await _db.Articulos
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();

            return affected > 0;
        }

        public IEnumerable<Articulos> FindAllAsync(Guid id)
        {
            var articulosTiendas = _db.ArticuloTiendas.Where(e => e.TiendaId == id);

            List<Articulos> articulos = new List<Articulos>();
            foreach (var item in articulosTiendas)
            {
                articulos.Add(_db.Articulos.FirstOrDefault(e => e.Id == item.ArticuloId));
            };
            return articulos;
        }

        public async Task<Articulos?> FindAsync(Guid id)
        {
            return await _db.Articulos
                .AsNoTracking()
                .FirstOrDefaultAsync(a =>  a.Id == id);
        }

        public async Task<bool> UpdateAsync(Articulos articulo)
        {
            var affected = await _db.Articulos
                .Where(a => a.Id == articulo.Id)
                .ExecuteUpdateAsync(updates => updates
                    .SetProperty(c => c.Imagen, articulo.Imagen)
                    .SetProperty(c => c.Descripcion, articulo.Descripcion)
                    .SetProperty(c => c.Stock, articulo.Stock)
                    .SetProperty(c => c.Nombre, articulo.Nombre)
                    .SetProperty(c => c.Precio, articulo.Precio)
                    
                );
            return affected > 0;
        }
    }
}
