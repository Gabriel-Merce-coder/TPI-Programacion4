using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Concesionaria.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservasController : ControllerBase
    {
        private readonly IReservaService reservaService;

        public ReservasController(IReservaService reservaService)
        {
            this.reservaService = reservaService;
        }

        // POST: api/Reservas
        [HttpPost]
        public ActionResult<ReservaResponse> Crear(
            [FromBody] CrearReservaRequest request)
        {
            try
            {
                var reserva = reservaService.Crear(request);

                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = reserva.Id },
                    reserva
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
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

        // GET: api/Reservas
        [HttpGet]
        public ActionResult<IReadOnlyList<ReservaResponse>> ObtenerTodas()
        {
            var reservas = reservaService.ObtenerTodas();

            if (!reservas.Any())
            {
                return NotFound("No hay reservas registradas.");
            }

            return Ok(reservas);
        }

        // GET: api/Reservas/1
        [HttpGet("{id:int}")]
        public ActionResult<ReservaResponse> ObtenerPorId(int id)
        {
            var reserva = reservaService.ObtenerPorId(id);

            if (reserva == null)
            {
                return NotFound(
                    $"No existe una reserva con el id {id}."
                );
            }

            return Ok(reserva);
        }

        // PUT: api/Reservas/1/confirmar
        [HttpPut("{id:int}/confirmar")]
        public ActionResult<ReservaResponse> Confirmar(int id)
        {
            try
            {
                var reserva = reservaService.Confirmar(id);

                return Ok(reserva);
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

        // PUT: api/Reservas/1/cancelar
        [HttpPut("{id:int}/cancelar")]
        public ActionResult<ReservaResponse> Cancelar(int id)
        {
            try
            {
                var reserva = reservaService.Cancelar(id);

                return Ok(reserva);
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