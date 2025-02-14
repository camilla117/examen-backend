using MiCarrito.Bussiness.Interfaces;
using MiCarrito.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MiCarrito.API.Controllers
{
    [Route("api/[controller]")]
    public class TiendaController : ControllerBase
    {
        private readonly ITienda _tienda;
        public TiendaController(ITienda tienda)
        {
            _tienda = tienda;
        }

        [HttpGet]
        public IActionResult GetAllTienda()
        {
            var tienda = _tienda.FindAllAsync();
            return Ok(tienda);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetArticulo(Guid id)
        {
            var tienda = await _tienda.FindAsync(id);

            if (tienda == null) return NotFound();

            return Ok(tienda);
        }

        [HttpPost]
        public async Task<IActionResult> AddArticulo([FromBody] Tienda tienda)
        {
            var newTienda = new Tienda
            {
                Id = Guid.NewGuid(),
                Direccion = tienda.Direccion,
                Sucursal = tienda.Sucursal
            };

            await _tienda.AddAsync(newTienda);
            return Ok(newTienda);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTinda([FromBody] Tienda tienda)
        {
            var updated = await _tienda.UpdateAsync(tienda);

            if (!updated) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteTienda(Guid id)
        {
            var deleted = await _tienda.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
