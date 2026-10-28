
using Concesionaria.Application.DTOs;
using Concesionaria.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Concesionaria.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministradoresController : ControllerBase
    {
        private readonly IAdministradorService administradorService;

        public AdministradoresController(IAdministradorService administradorService)
        {
            this.administradorService = administradorService;
        }

        // POST: api/Administradores
        [HttpPost]
        public ActionResult<AdministradorResponse> Crear(
            [FromBody] CrearAdministradorRequest request)
        {
            try
            {
                var administrador = administradorService.Crear(request);

                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = administrador.Id },
                    administrador
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

        // GET: api/Administradores
        [HttpGet]
        [Authorize(Policy = Policies.AdminsOnly)]
        public ActionResult<IReadOnlyList<AdministradorResponse>> ObtenerTodos()
        {
            var administradores = administradorService.ObtenerTodos();

            if (!administradores.Any())
            {
                return NotFound("No hay administradores registrados.");
            }

            return Ok(administradores);
        }

        // GET: api/Administradores/1
        [HttpGet("{id:int}")]
        [Authorize(Policy = Policies.AdminsOnly)]
        public ActionResult<AdministradorResponse> ObtenerPorId(int id)
        {
            var administrador = administradorService.ObtenerPorId(id);

            if (administrador == null)
            {
                return NotFound($"No existe un administrador con el id {id}.");
            }

            return Ok(administrador);
        }
    }
}
