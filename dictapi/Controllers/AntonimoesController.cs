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
    public class AntonimoesController : ControllerBase
    {
        private readonly DictdbContext _context;

        public AntonimoesController(DictdbContext context)
        {
            _context = context;
        }

        // GET: api/Antonimoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Antonimo>>> GetAntonimos()
        {
            return await _context.Antonimos.ToListAsync();
        }

        // GET: api/Antonimoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Antonimo>> GetAntonimo(int id)
        {
            var antonimo = await _context.Antonimos.FindAsync(id);

            if (antonimo == null)
            {
                return NotFound();
            }

            return antonimo;
        }

        // PUT: api/Antonimoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAntonimo(int id, Antonimo antonimo)
        {
            if (id != antonimo.Idant)
            {
                return BadRequest();
            }

            _context.Entry(antonimo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AntonimoExists(id))
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

        // POST: api/Antonimoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Antonimo>> PostAntonimo(Antonimo antonimo)
        {
            _context.Antonimos.Add(antonimo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAntonimo", new { id = antonimo.Idant }, antonimo);
        }

        // DELETE: api/Antonimoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAntonimo(int id)
        {
            var antonimo = await _context.Antonimos.FindAsync(id);
            if (antonimo == null)
            {
                return NotFound();
            }

            _context.Antonimos.Remove(antonimo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AntonimoExists(int id)
        {
            return _context.Antonimos.Any(e => e.Idant == id);
        }
    }
}
