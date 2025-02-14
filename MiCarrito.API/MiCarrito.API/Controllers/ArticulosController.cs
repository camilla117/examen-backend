using MiCarrito.API.Dtos;
using MiCarrito.Bussiness.Interfaces;
using MiCarrito.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MiCarrito.API.Controllers
{
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticulos _articulos;
        private readonly IArticuloTienda _articuloTienda;

        public ArticulosController(IArticulos articulos, IArticuloTienda articuloTienda)
        {
            _articulos = articulos;
            _articuloTienda = articuloTienda;

        }

        [HttpGet("list/{id:guid}")]
        public IActionResult GetAllArticulos(Guid id)
        {
            var articulos = _articulos.FindAllAsync(id);
            return Ok(articulos);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetArticulo(Guid id)
        {
            var articulo = await _articulos.FindAsync(id);

            if (articulo == null) return NotFound();

            return Ok(articulo);
        }


        [HttpPost("{id:guid}")]
        public async Task<IActionResult> AddArticulo([FromBody] ArticulosDto articulo, Guid id)
        {
            var newArticulo = new Articulos
            {
                Id = Guid.NewGuid(),
                Nombre = articulo.Nombre,
                Descripcion = articulo.Descripcion,
                Imagen = articulo.Imagen,
                Precio = articulo.Precio,
                Stock = articulo.Stock
            };

            await _articulos.AddAsync(newArticulo);

            var articuloTienda = new ArticuloTienda
            {
                ArticuloId = newArticulo.Id,
                TiendaId = id
            };
            await _articuloTienda.AddAsync(articuloTienda);
            return Ok(newArticulo);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArticulo([FromBody] ArticulosDto articulo)
        {
            var newArticulo = new Articulos
            {
                Descripcion = articulo.Descripcion,
                Imagen = articulo.Imagen,
                Nombre = articulo.Nombre,
                Id = articulo.Id,
                Precio = articulo.Precio,
                Stock = articulo.Stock
            };

            var updated = await _articulos.UpdateAsync(newArticulo);

            if(!updated) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id:guid}/{idTienda:guid}")]
        public async Task<IActionResult> DeleteArticulo(Guid id, Guid idTienda)
        {
            var deleted = await _articulos.DeleteAsync(id);
            if (!deleted) return NotFound();
            await _articuloTienda.DeleteAsync(id, idTienda);

            return NoContent();
        }
    }
}
