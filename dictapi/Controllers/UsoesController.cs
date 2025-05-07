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
    public class UsoesController : ControllerBase
    {
        private readonly DictdbContext _context;

        public UsoesController(DictdbContext context)
        {
            _context = context;
        }

        // GET: api/Usoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uso>>> GetUsos()
        {
            return await _context.Usos.ToListAsync();
        }

        // GET: api/Usoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uso>> GetUso(int id)
        {
            var uso = await _context.Usos.FindAsync(id);

            if (uso == null)
            {
                return NotFound();
            }

            return uso;
        }

        // PUT: api/Usoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUso(int id, Uso uso)
        {
            if (id != uso.Id)
            {
                return BadRequest();
            }

            _context.Entry(uso).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsoExists(id))
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

        // POST: api/Usoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Uso>> PostUso(Uso uso)
        {
            _context.Usos.Add(uso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUso", new { id = uso.Id }, uso);
        }

        // DELETE: api/Usoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUso(int id)
        {
            var uso = await _context.Usos.FindAsync(id);
            if (uso == null)
            {
                return NotFound();
            }

            _context.Usos.Remove(uso);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsoExists(int id)
        {
            return _context.Usos.Any(e => e.Id == id);
        }
    }
}
