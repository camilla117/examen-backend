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
    public class ClienteArticuloRepository(CarritoDbContext db) : IClienteArticulo
    {
        private readonly CarritoDbContext _db = db;
        public async Task AddAsync(ClienteArticulo articulo)
        {
            articulo.Fecha = DateTime.Now;
            _db.ClienteArticulos.Add(articulo);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var affected = await _db.ClienteArticulos
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();

            return affected > 0;
        }

        public IEnumerable<ClienteArticulo> FindAllAsync()
        {
            return _db.ClienteArticulos
                .AsNoTracking();
        }

        public async Task<ClienteArticulo?> FindAsync(Guid id)
        {
            return await _db.ClienteArticulos
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> UpdateAsync(ClienteArticulo articulo)
        {
            var affected = await _db.ClienteArticulos
               .Where(a => a.Id == articulo.Id)
               .ExecuteUpdateAsync(updates => updates
                   .SetProperty(e => e.ClienteId, articulo.ClienteId)
                   .SetProperty(e => e.ArticuloId, articulo.ArticuloId)
               );
            return affected > 0;
        }
    }
}
