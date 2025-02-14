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
    public class ArticuloTiendaRepository(CarritoDbContext db) : IArticuloTienda
    {
        private readonly CarritoDbContext _db = db;

        public async Task AddAsync(ArticuloTienda articulo)
        {
            articulo.Fecha = DateTime.Now;
            _db.ArticuloTiendas.Add(articulo);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id, Guid idTienda)
        {
            var affected = await _db.ArticuloTiendas
                .Where(a => a.ArticuloId == id && a.TiendaId == idTienda)
                .ExecuteDeleteAsync();

            return affected > 0;
        }

        public IEnumerable<ArticuloTienda> FindAllAsync()
        {
            return _db.ArticuloTiendas
                .AsNoTracking();
        }

        public async Task<ArticuloTienda?> FindAsync(Guid id)
        {
            return await _db.ArticuloTiendas
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> UpdateAsync(ArticuloTienda articulo)
        {
            var affected = await _db.ArticuloTiendas
                .Where(a => a.Id == articulo.Id)
                .ExecuteUpdateAsync(updates => updates
                    .SetProperty(e => e.TiendaId, articulo.TiendaId)
                    .SetProperty(e => e.ArticuloId, articulo.ArticuloId)
                );
            return affected > 0;
        }
    }
}
