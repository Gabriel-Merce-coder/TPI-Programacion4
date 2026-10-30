
using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Concesionaria.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentasController : ControllerBase
    {
        private readonly IVentaService ventaService;

        public VentasController(IVentaService ventaService)
        {
            this.ventaService = ventaService;
        }

        [HttpPost]
        public ActionResult<VentaResponse> Crear(
            [FromBody] CrearVentaRequest request)
        {
            try
            {
                var venta = ventaService.Crear(request);

                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = venta.Id },
                    venta
                );
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
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

        [HttpGet("{id:int}")]
        public ActionResult<VentaResponse> ObtenerPorId(int id)
        {
            var venta = ventaService.ObtenerPorId(id);

            if (venta == null)
            {
                return NotFound(
                    $"No existe una venta con el ID {id}."
                );
            }

            return Ok(venta);
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<VentaResponse>> ObtenerTodas()
        {
            return Ok(ventaService.ObtenerTodas());
        }
    }
}
