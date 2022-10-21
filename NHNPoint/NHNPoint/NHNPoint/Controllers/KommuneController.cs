using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointDatabase;

namespace NHNPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KommuneController : ControllerBase
    {
        private readonly Entities _context;
        /// <summary>
        /// Contains Kommuner
        /// </summary>
        /// <param name="context"></param>

        public KommuneController(Entities context)
        {
            _context = context;
        }

        // GET: api/Kommune
        /// <summary>
        /// Gets all Kommuner
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kommune>>> GetKommune()
        {
          if (_context.Kommune == null)
          {
              return NotFound();
          }
            return await _context.Kommune.ToListAsync();
        }

        // GET: api/Kommune/5
        /// <summary>
        /// Gets a specific Kommune
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Kommune>> GetKommune(int id)
        {
          if (_context.Kommune == null)
          {
              return NotFound();
          }
            var kommune = await _context.Kommune.FindAsync(id);

            if (kommune == null)
            {
                return NotFound();
            }

            return kommune;
        }

        // PUT: api/Kommune/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Kommune
        /// </summary>
        /// <param name="id"></param>
        /// <param name="kommune"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKommune(int id, Kommune kommune)
        {
            if (id != kommune.Id)
            {
                return BadRequest();
            }

            _context.Entry(kommune).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KommuneExists(id))
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

        // POST: api/Kommune
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Kommune
        /// </summary>
        /// <param name="kommune"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Kommune>> PostKommune(Kommune kommune)
        {
          if (_context.Kommune == null)
          {
              return Problem("Entity set 'Entities.Kommune'  is null.");
          }
            _context.Kommune.Add(kommune);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKommune", new { id = kommune.Id }, kommune);
        }

        // DELETE: api/Kommune/5
        /// <summary>
        /// deletes a specific Kommune
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKommune(int id)
        {
            if (_context.Kommune == null)
            {
                return NotFound();
            }
            var kommune = await _context.Kommune.FindAsync(id);
            if (kommune == null)
            {
                return NotFound();
            }

            _context.Kommune.Remove(kommune);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KommuneExists(int id)
        {
            return (_context.Kommune?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
