using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiCarrito.Bussiness.Interfaces;

using MiCarrito.Data;
using MiCarrito.Entities;
using Microsoft.EntityFrameworkCore;

namespace MiCarrito.Bussiness.Repositories
{
    public class ClientesRepository(CarritoDbContext db) : IClientes
    {
        private readonly CarritoDbContext _db = db;
        public async Task AddAsync(Clientes articulo)
        {
            _db.Clientes.Add(articulo);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var affected = await _db.Clientes
                .Where(a => a.Id == id)
                .ExecuteDeleteAsync();

            return affected > 0;
        }

        public IEnumerable<Clientes> FindAllAsync()
        {
            return _db.Clientes
                .AsNoTracking();
        }

        public async Task<Clientes?> FindAsync(Guid id)
        {
            return await _db.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Clientes?> Login(string username, string password)
        {
            return await _db.Clientes
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Usuario == username && e.Password == password);
        }

        public async Task<bool> UpdateAsync(Clientes articulo)
        {
            var affected = await _db.Clientes
                .Where(a => a.Id == articulo.Id)
                .ExecuteUpdateAsync(updates => updates
                    .SetProperty(e => e.Password, articulo.Password)
                    .SetProperty(e => e.Usuario, articulo.Usuario)
                    .SetProperty(e => e.Nombre, articulo.Nombre)
                    .SetProperty(e => e.Direccion, articulo.Direccion)
                    .SetProperty(e => e.Apellidos, articulo.Apellidos)

                );
            return affected > 0;
        }
    }
}
