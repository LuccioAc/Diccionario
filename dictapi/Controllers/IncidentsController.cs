using dictapi.Dtos;
using dictapi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace dictapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidentService _incidentService;

        public IncidentsController(IIncidentService incidentService)
        {
            _incidentService = incidentService;
        }

        // POST: api/Incidents
        // Crear incidente (usuario autenticado)
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CrearIncidente([FromBody] IncidentCreateDto dto)
        {
            var codeusr = User.FindFirstValue("codeusr");
            if (string.IsNullOrEmpty(codeusr))
                return Unauthorized("Usuario no válido");

            var creado = await _incidentService.CreateIncidentAsync(codeusr, dto);
            return creado ? Ok("Incidente creado") : BadRequest("No se pudo crear el incidente");
        }

        // GET: api/Incidents
        // Obtener todos los incidentes (solo admin)
        [Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<List<IncidentGetDtos>>> ObtenerTodos()
        {
            var incidentes = await _incidentService.GetAllIncidentsAsync();
            return Ok(incidentes);
        }

        // PUT: api/Incidents/estado/5
        // Cambiar estado de un incidente (solo admin)
        [Authorize(Roles = "admin")]
        [HttpPut("estado/{id}")]
        public async Task<IActionResult> CambiarEstado(int id, [FromBody] IncidentStatusUpdateDto dto)
        {
            var actualizado = await _incidentService.ChangeIncidentStateAsync(id, dto.Activo);
            return actualizado ? Ok("Estado actualizado") : NotFound("Incidente no encontrado");
        }

        // DELETE: api/Incidents/5
        // Eliminar incidente (solo admin)
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarIncidente(int id)
        {
            var eliminado = await _incidentService.DeleteIncidentAsync(id);
            return eliminado ? Ok("Incidente eliminado") : NotFound("Incidente no encontrado");
        }
    }
}
