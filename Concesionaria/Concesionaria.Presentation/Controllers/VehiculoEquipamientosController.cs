using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Concesionaria.Presentation.Controllers
{
    [ApiController]
    [Route("api/Vehiculos/{vehiculoId:int}/Equipamientos")]
    [Authorize]
    public class VehiculoEquipamientosController : ControllerBase
    {
        private readonly IVehiculoEquipamientoService vehiculoEquipamientoService;

        public VehiculoEquipamientosController(
            IVehiculoEquipamientoService vehiculoEquipamientoService)
        {
            this.vehiculoEquipamientoService = vehiculoEquipamientoService;
        }

        // GET: api/Vehiculos/1/Equipamientos
        [HttpGet]
        public ActionResult<IReadOnlyList<EquipamientoResponse>> ObtenerEquipamientos(
            int vehiculoId)
        {
            try
            {
                return Ok(vehiculoEquipamientoService.ObtenerEquipamientos(vehiculoId));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        // POST: api/Vehiculos/1/Equipamientos/2
        [Authorize(Policy = Policies.AdminsOnly)]
        [HttpPost("{equipamientoId:int}")]
        public IActionResult Asignar(int vehiculoId, int equipamientoId)
        {
            try
            {
                vehiculoEquipamientoService.Asignar(vehiculoId, equipamientoId);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        // DELETE: api/Vehiculos/1/Equipamientos/2
        [Authorize(Policy = Policies.AdminsOnly)]
        [HttpDelete("{equipamientoId:int}")]
        public IActionResult Quitar(int vehiculoId, int equipamientoId)
        {
            try
            {
                vehiculoEquipamientoService.Quitar(vehiculoId, equipamientoId);

                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}