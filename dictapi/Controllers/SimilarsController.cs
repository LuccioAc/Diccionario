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
    public class SimilarsController : ControllerBase
    {
        private readonly DictdbContext _context;

        public SimilarsController(DictdbContext context)
        {
            _context = context;
        }

        // GET: api/Similars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Similar>>> GetSimilars()
        {
            return await _context.Similars.ToListAsync();
        }

        // GET: api/Similars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Similar>> GetSimilar(int id)
        {
            var similar = await _context.Similars.FindAsync(id);

            if (similar == null)
            {
                return NotFound();
            }

            return similar;
        }

        // PUT: api/Similars/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSimilar(int id, Similar similar)
        {
            if (id != similar.Idsim)
            {
                return BadRequest();
            }

            _context.Entry(similar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SimilarExists(id))
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

        // POST: api/Similars
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Similar>> PostSimilar(Similar similar)
        {
            _context.Similars.Add(similar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSimilar", new { id = similar.Idsim }, similar);
        }

        // DELETE: api/Similars/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSimilar(int id)
        {
            var similar = await _context.Similars.FindAsync(id);
            if (similar == null)
            {
                return NotFound();
            }

            _context.Similars.Remove(similar);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SimilarExists(int id)
        {
            return _context.Similars.Any(e => e.Idsim == id);
        }
    }
}
