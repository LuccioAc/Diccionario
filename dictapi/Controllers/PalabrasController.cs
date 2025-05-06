using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dictapi.Models;

namespace dictapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PalabrasController : ControllerBase
    {
        private readonly DictionaryContext _context;

        public PalabrasController(DictionaryContext context)
        {
            _context = context;
        }

        // GET: api/Palabras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Palabra>>> GetPalabras()
        {
            return await _context.Palabras.ToListAsync();
        }

        // GET: api/Palabras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Palabra>> GetPalabra(int id)
        {
            var palabra = await _context.Palabras.FindAsync(id);

            if (palabra == null)
            {
                return NotFound();
            }

            return palabra;
        }

        // PUT: api/Palabras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPalabra(int id, Palabra palabra)
        {
            if (id != palabra.Idword)
            {
                return BadRequest();
            }

            _context.Entry(palabra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PalabraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Palabras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Palabra>> PostPalabra(Palabra palabra)
        {
            _context.Palabras.Add(palabra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPalabra", new { id = palabra.Idword }, palabra);
        }

        // DELETE: api/Palabras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePalabra(int id)
        {
            var palabra = await _context.Palabras.FindAsync(id);
            if (palabra == null)
            {
                return NotFound();
            }

            _context.Palabras.Remove(palabra);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PalabraExists(int id)
        {
            return _context.Palabras.Any(e => e.Idword == id);
        }
    }
}
