using MiCarrito.Entities;
using Microsoft.EntityFrameworkCore;

namespace MiCarrito.Data
{
    public class CarritoDbContext : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Tienda> Tienda { get; set; }
        public DbSet<ClienteArticulo> ClienteArticulos { get; set; }
        public DbSet<ArticuloTienda> ArticuloTiendas { get; set; }
        public CarritoDbContext(DbContextOptions<CarritoDbContext> opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { }
        
    }
}
