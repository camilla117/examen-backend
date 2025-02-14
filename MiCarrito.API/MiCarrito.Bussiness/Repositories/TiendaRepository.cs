using MiCarrito.Bussiness.Interfaces;
using MiCarrito.Data;
using MiCarrito.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiCarrito.Bussiness.Repositories
{
    public class TiendaRepository(CarritoDbContext db) : ITienda
    {
        private readonly CarritoDbContext _db = db;
        public async Task AddAsync(Tienda articulo)
        {
            _db.Tienda.Add(articulo);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var affected = await _db.Tienda
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();

            return affected > 0;
        }

        public IEnumerable<Tienda> FindAllAsync()
        {
            return _db.Tienda
               .AsNoTracking();
        }

        public async Task<Tienda?> FindAsync(Guid id)
        {
            return await _db.Tienda
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> UpdateAsync(Tienda articulo)
        {
            var affected = await _db.Tienda
                .Where(a => a.Id == articulo.Id)
                .ExecuteUpdateAsync(updates => updates
                    .SetProperty(e => e.Sucursal, articulo.Sucursal)
                    .SetProperty(e => e.Direccion, articulo.Direccion)
                );
            return affected > 0;
        }
    }
}
