using dictapi.Dtos;
using dictapi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dictapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsoesController : ControllerBase
    {
        private readonly IUseService _useService;

        public UsoesController(IUseService useService)
        {
            _useService = useService;
        }

        //Público GET: api/Usoes/palabra/5
        [HttpGet("palabra/{idword}")]
        public async Task<ActionResult<IEnumerable<UsoDtos>>> GetUsosByWordId(int idword)
        {
            var usos = await _useService.GetUsosByWordIdAsync(idword);
            return Ok(usos);
        }

        //Solo admin POST: api/Usoes
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUso([FromBody] UsoDto dto)
        {
            var creado = await _useService.CreateUsoAsync(dto);
            if (!creado) return BadRequest("No se pudo crear el uso. Verifique que la palabra exista.");
            return Ok(new { message = "Uso creado correctamente." });
        }

        //Solo admin PUT: api/Usoes/5
        [Authorize(Roles = "admin")]
        [HttpPut("{iduse}")]
        public async Task<IActionResult> UpdateUso(int iduse, [FromBody] UsoUpdateDto dto)
        {
            var actualizado = await _useService.UpdateUsoAsync(iduse, dto);
            if (!actualizado) return NotFound("No se encontró el uso a actualizar.");
            return Ok(new { message = "Uso actualizado correctamente." });
        }

        //Solo admin DELETE: api/Usoes/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{iduse}")]
        public async Task<IActionResult> DeleteUso(int iduse)
        {
            var eliminado = await _useService.DeleteUsoAsync(iduse);
            if (!eliminado) return NotFound("No se encontró el uso a eliminar.");
            return Ok(new { message = "Uso eliminado correctamente." });
        }
    }
}
