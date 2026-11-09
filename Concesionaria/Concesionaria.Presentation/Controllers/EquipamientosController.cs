using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Concesionaria.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EquipamientosController : ControllerBase
    {
        private readonly IEquipamientoService equipamientoService;

        public EquipamientosController(IEquipamientoService equipamientoService)
        {
            this.equipamientoService = equipamientoService;
        }

        // POST: api/Equipamientos
        [Authorize(Policy = Policies.AdminsOnly)]
        [HttpPost]
        public ActionResult<EquipamientoResponse> Crear(
            [FromBody] CrearEquipamientoRequest request)
        {
            try
            {
                var equipamiento = equipamientoService.Crear(request);

                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = equipamiento.Id },
                    equipamiento
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Equipamientos
        [HttpGet]
        public ActionResult<IReadOnlyList<EquipamientoResponse>> ObtenerTodos()
        {
            var equipamientos = equipamientoService.ObtenerTodos();

            if (!equipamientos.Any())
            {
                return NotFound("No hay equipamientos registrados.");
            }

            return Ok(equipamientos);
        }

        // GET: api/Equipamientos/1
        [HttpGet("{id:int}")]
        public ActionResult<EquipamientoResponse> ObtenerPorId(int id)
        {
            var equipamiento = equipamientoService.ObtenerPorId(id);

            if (equipamiento == null)
            {
                return NotFound($"No existe un equipamiento con el id {id}.");
            }

            return Ok(equipamiento);
        }

        // PUT: api/Equipamientos/1
        [Authorize(Policy = Policies.AdminsOnly)]
        [HttpPut("{id:int}")]
        public ActionResult<EquipamientoResponse> Actualizar(
            int id,
            [FromBody] ActualizarEquipamientoRequest request)
        {
            try
            {
                var equipamiento = equipamientoService.Actualizar(id, request);

                if (equipamiento == null)
                {
                    return NotFound($"No existe un equipamiento con el id {id}.");
                }

                return Ok(equipamiento);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}