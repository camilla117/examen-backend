using MiCarrito.Bussiness.Interfaces;
using MiCarrito.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MiCarrito.API.Controllers
{
    [Route("api/[controller]")]
    public class ClienteArticuloController : ControllerBase
    {
        private readonly IClienteArticulo _clientes;
        private readonly IArticulos _articulos;

        public ClienteArticuloController(IClienteArticulo clientes, IArticulos articulos)
        {
            _clientes = clientes;
            _articulos = articulos;
        }

        [HttpGet]
        public IActionResult GetAllClientes()
        {
            var clientes = _clientes.FindAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetClienteArticulo(Guid id)
        {
            var cliente = await _clientes.FindAsync(id);

            if (cliente == null) return NotFound();

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> AddClienteArticulo([FromBody] ClienteArticulo cliente)
        {
            var newCliente = new ClienteArticulo
            {
                Id = Guid.NewGuid(),
                ArticuloId = cliente.ArticuloId,
                ClienteId = cliente.ClienteId,
                Cantidad = cliente.Cantidad,
                Fecha = DateTime.Now,
                IdCompra = cliente.IdCompra,
                Total = cliente.Total,
            };

            await _clientes.AddAsync(newCliente);
            var newArticulo = await _articulos.FindAsync(cliente.ArticuloId);
            newArticulo.Stock = newArticulo.Stock - cliente.Cantidad;
            await _articulos.UpdateAsync(newArticulo);
            return Ok(newCliente);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateClienteArticulo([FromBody] ClienteArticulo cliente)
        {
            var updated = await _clientes.UpdateAsync(cliente);

            if (!updated) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteClienteArticulo(Guid id)
        {
            var deleted = await _clientes.DeleteAsync(id);

            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
