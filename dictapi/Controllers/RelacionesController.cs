using dictapi.Dtos;
using dictapi.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dictapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RelacionesController : ControllerBase
    {
        private readonly IRelationService _relationService;

        public RelacionesController(IRelationService relationService)
        {
            _relationService = relationService;
        }

        // ======== SINÓNIMOS ========

        [HttpGet("sinonimos/{idWord}")]
        public async Task<IActionResult> GetSynonyms(int idWord)
        {
            var result = await _relationService.GetSynonymsAsync(idWord);
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("sinonimos")]
        public async Task<IActionResult> CreateSynonym([FromBody] SynonymCUDto dto)
        {
            var result = await _relationService.CreateSynonymAsync(dto);
            return result ? Ok() : BadRequest("Error al crear sinónimo.");
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("sinonimos")]
        public async Task<IActionResult> DeleteSynonym([FromBody] SynonymCUDto dto)
        {
            var result = await _relationService.DeleteSynonymAsync(dto);
            return result ? Ok() : NotFound("Sinónimo no encontrado.");
        }

        // ======== ANTÓNIMOS ========

        [HttpGet("antonimos/{idWord}")]
        public async Task<IActionResult> GetAntonyms(int idWord)
        {
            var result = await _relationService.GetAntonymsAsync(idWord);
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("antonimos")]
        public async Task<IActionResult> CreateAntonym([FromBody] AntonymCUDto dto)
        {
            var result = await _relationService.CreateAntonymAsync(dto);
            return result ? Ok() : BadRequest("Error al crear antónimo.");
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("antonimos")]
        public async Task<IActionResult> DeleteAntonym([FromBody] AntonymCUDto dto)
        {
            var result = await _relationService.DeleteAntonymAsync(dto);
            return result ? Ok() : NotFound("Antónimo no encontrado.");
        }

        // ======== SIMILARES ========

        [HttpGet("similares/{idWord}")]
        public async Task<IActionResult> GetSimilars(int idWord)
        {
            var result = await _relationService.GetSimilarsAsync(idWord);
            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("similares")]
        public async Task<IActionResult> CreateSimilar([FromBody] SimilarCUDto dto)
        {
            var result = await _relationService.CreateSimilarAsync(dto);
            return result ? Ok() : BadRequest("Error al crear relación de similitud.");
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("similares")]
        public async Task<IActionResult> DeleteSimilar([FromBody] SimilarCUDto dto)
        {
            var result = await _relationService.DeleteSimilarAsync(dto);
            return result ? Ok() : NotFound("Relación de similitud no encontrada.");
        }
    }
}
