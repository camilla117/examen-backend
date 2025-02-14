using MiCarrito.Bussiness.Interfaces;
using MiCarrito.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MiCarrito.API.Controllers
{
    [Route("api/[controller]")]
    public class ArticuloTiendaController : ControllerBase
    {
        private readonly IArticuloTienda _articulos;

        public ArticuloTiendaController(IArticuloTienda articulos)
        {
            _articulos = articulos;
        }

        [HttpGet]
        public IActionResult GetAllArticulosTienda()
        {
            var articulos = _articulos.FindAllAsync();
            return Ok(articulos);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetArticuloTienda(Guid id)
        {
            var articulo = await _articulos.FindAsync(id);

            if (articulo == null) return NotFound();

            return Ok(articulo);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticulo([FromBody] ArticuloTienda articulo)
        {
            var newArticulo = new ArticuloTienda
            {
                Id = Guid.NewGuid(),
                ArticuloId = articulo.Id,
                TiendaId = articulo.TiendaId,
                Fecha = articulo.Fecha,
            };

            await _articulos.AddAsync(newArticulo);
            return Ok(newArticulo);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateArticulo([FromBody] ArticuloTienda articulo)
        {
            var updated = await _articulos.UpdateAsync(articulo);

            if (!updated) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteArticulo(Guid id)
        {
            var deleted = await _articulos.DeleteAsync(id, Guid.NewGuid());

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
