using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Concesionaria.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService clienteService;

        public ClientesController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        // POST: api/Clientes
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<ClienteResponse> Crear(
            [FromBody] CrearClienteRequest request)
        {
            try
            {
                var cliente = clienteService.Crear(request);

                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = cliente.Id },
                    cliente
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // GET: api/Clientes
        [Authorize(Policy = Policies.AdminsOnly)]
        [HttpGet]
        public ActionResult<IReadOnlyList<ClienteResponse>> ObtenerTodos()
        {
            var clientes = clienteService.ObtenerTodos();

            if (!clientes.Any())
            {
                return NotFound("No hay clientes registrados.");
            }

            return Ok(clientes);
        }

        // GET: api/Clientes/1
        [Authorize(Policy = Policies.AdminsOnly)]
        [HttpGet("{id:int}")]
        public ActionResult<ClienteResponse> ObtenerPorId(int id)
        {
            var cliente = clienteService.ObtenerPorId(id);

            if (cliente == null)
            {
                return NotFound($"No existe un cliente con el id {id}.");
            }

            return Ok(cliente);
        }
    }
}