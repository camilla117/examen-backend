using MiCarrito.Bussiness.Interfaces;
using MiCarrito.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MiCarrito.API.Controllers
{
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClientes _clientes;

        public ClientesController(IClientes clientes)
        {
            _clientes = clientes;
        }

        [HttpGet]
        public IActionResult GetAllClientes()
        {
            var clientes = _clientes.FindAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCliente(Guid id)
        {
            var cliente = await _clientes.FindAsync(id);

            if (cliente == null) return NotFound();

            return Ok(cliente);
        }

        [HttpGet("login")]
        public async Task<IActionResult> Login(Clientes cliente)
        {
            var clienteExists = await _clientes.Login(cliente.Usuario, cliente.Password);

            if (clienteExists == null) return NotFound();

            return Ok(clienteExists);
        }

        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] Clientes cliente)
        {
            var newCliente = new Clientes
            {
                Id = Guid.NewGuid(),
                Direccion = cliente.Direccion,
                Nombre = cliente.Nombre,
                Apellidos = cliente.Apellidos,
                Password = cliente.Password,
                Usuario = cliente.Usuario
            };

            await _clientes.AddAsync(newCliente);
            return Ok(newCliente);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCliente([FromBody] Clientes cliente)
        {
            var updated = await _clientes.UpdateAsync(cliente);

            if (!updated) return NotFound();

            return Ok(updated);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteCliente(Guid id)
        {
            var deleted = await _clientes.DeleteAsync(id);
            if (!deleted) return NotFound();

            return NoContent();
        }
    }
}
