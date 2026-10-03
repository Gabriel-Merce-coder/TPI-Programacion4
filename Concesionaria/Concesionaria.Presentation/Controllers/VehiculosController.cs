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

        // POST: api/Vehiculos
        [HttpPost]
        public ActionResult<VehiculoResponse> Crear(
            [FromBody] CrearVehiculoRequest request)
        {
            try
            {
                var vehiculo = vehiculoService.Crear(request);

                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = vehiculo.Id },
                    vehiculo
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Vehiculos
        [HttpGet]
        public ActionResult<IReadOnlyList<VehiculoResponse>> ObtenerTodos()
        {
            var vehiculos = vehiculoService.ObtenerTodos();

            if (!vehiculos.Any())
            {
                return NotFound("No hay vehículos registrados.");
            }

            return Ok(vehiculos);
        }

        // GET: api/Vehiculos/1
        [HttpGet("{id:int}")]
        public ActionResult<VehiculoResponse> ObtenerPorId(int id)
        {
            var vehiculo = vehiculoService.ObtenerPorId(id);

            if (vehiculo == null)
            {
                return NotFound(
                    $"No existe un vehículo con el id {id}."
                );
            }

            return Ok(vehiculo);
        }

        // PUT: api/Vehiculos/1
        [HttpPut("{id:int}")]
        public ActionResult<VehiculoResponse> Actualizar(
            int id,
            [FromBody] ActualizarVehiculoRequest request)
        {
            try
            {
                var vehiculo = vehiculoService.Actualizar(id, request);

                if (vehiculo == null)
                {
                    return NotFound(
                        $"No existe un vehículo con el id {id}."
                    );
                }

                return Ok(vehiculo);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Vehiculos/1
        [HttpDelete("{id:int}")]
        public IActionResult DarDeBaja(int id)
        {
            try
            {
                var resultado = vehiculoService.DarDeBaja(id);

                if (!resultado)
                {
                    return NotFound(
                        $"No existe un vehículo con el id {id}."
                    );
                }

                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}