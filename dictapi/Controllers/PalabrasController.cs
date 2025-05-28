using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using dictapi.Dtos;
using dictapi.Interfaces;

namespace dictapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalabrasController : ControllerBase
    {
        private readonly IWordService _wordService;

        public PalabrasController(IWordService wordService)
        {
            _wordService = wordService;
        }

        //Público: obtener lista resumida de palabras (id + palabra)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IdnWordDto>>> GetPalabras()
        {
            var palabras = await _wordService.SearchWordAsync();
            return Ok(palabras);
        }

        //Público: obtener palabra completa (con relaciones)
        [HttpGet("{id}")]
        public async Task<ActionResult<WordDtos>> GetPalabra(int id)
        {
            var palabra = await _wordService.GetFullWordAsync(id);
            if (palabra == null)
                return NotFound();

            return Ok(palabra);
        }

        //Solo Admin: crear palabra
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> PostPalabra([FromBody] WordnMeaningDto dto)
        {
            var creado = await _wordService.CreateWordAsync(dto);
            if (!creado)
                return BadRequest("Ya existe una palabra con ese nombre.");

            return Ok("Palabra creada correctamente.");
        }

        //Solo Admin: actualizar palabra
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPalabra(int id, [FromBody] WordnMeaningDto dto)
        {
            var actualizado = await _wordService.UpdateWordAsync(id, dto);
            if (!actualizado)
                return NotFound("Palabra no encontrada.");

            return Ok("Palabra actualizada.");
        }

        //Solo Admin: eliminar palabra
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePalabra(int id)
        {
            var eliminado = await _wordService.DeleteWordAsync(id);
            if (!eliminado)
                return NotFound("Palabra no encontrada.");

            return Ok("Palabra eliminada.");
        }
    }
}
