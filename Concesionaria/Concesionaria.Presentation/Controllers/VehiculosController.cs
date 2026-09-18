using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Concesionaria.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiculosController : ControllerBase
    {
        private readonly IVehiculoService vehiculoService;

        public VehiculosController(IVehiculoService vehiculoService)
        {
            this.vehiculoService = vehiculoService;
        }

        [HttpPost]
        public ActionResult<VehiculoResponse> Crear(
            [FromBody] CrearVehiculoRequest request)
        {
            var vehiculo = vehiculoService.Crear(request);

            return CreatedAtAction(
                nameof(ObtenerPorId),
                new { id = vehiculo.Id },
                vehiculo
            );
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<VehiculoResponse>> ObtenerTodos()
        {
            var vehiculos = vehiculoService.ObtenerTodos();

            return Ok(vehiculos);
        }

        [HttpGet("{id:int}")]
        public ActionResult<VehiculoResponse> ObtenerPorId(int id)
        {
            var vehiculo = vehiculoService.ObtenerPorId(id);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return Ok(vehiculo);
        }

        [HttpPut("{id:int}")]
        public ActionResult<VehiculoResponse> Actualizar(
            int id,
            [FromBody] ActualizarVehiculoRequest request)
        {
            var vehiculo = vehiculoService.Actualizar(id, request);

            if (vehiculo == null)
            {
                return NotFound();
            }

            return Ok(vehiculo);
        }

        [HttpDelete("{id:int}")]
        public IActionResult DarDeBaja(int id)
        {
            var resultado = vehiculoService.DarDeBaja(id);

            if (!resultado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}