using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProduktDatabase;

namespace NHNProdukt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsController : ControllerBase
    {
        private readonly Entities _context;

        /// <summary>
        /// Contains the Options
        /// </summary>
        /// <param name="context"></param>
        public OptionsController(Entities context)
        {
            _context = context;
        }

        // GET: api/Options
        /// <summary>
        /// Gets all Components
        /// </summary>
        /// <returns>ActionResult IEnumerable Options</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Options>>> GetOptions()
        {
          if (_context.Options == null)
          {
              return NotFound();
          }
            return await _context.Options.ToListAsync();
        }

        // GET: api/Options/5
        /// <summary>
        /// Gets a specific Component
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult Options</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Options>> GetOption(int id)
        {
          if (_context.Options == null)
          {
              return NotFound();
          }
            var tilvalg = await _context.Options.FindAsync(id);

            if (tilvalg == null)
            {
                return NotFound();
            }

            return tilvalg;
        }

        // PUT: api/Options/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Component
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tilvalg"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOption(int id, Options tilvalg)
        {
            if (id != tilvalg.Id)
            {
                return BadRequest();
            }

            _context.Entry(tilvalg).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionExists(id))
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

        // POST: api/Options
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Component
        /// </summary>
        /// <param name="tilvalg"></param>
        /// <returns>ActionResult Options</returns>
        [HttpPost]
        public async Task<ActionResult<Options>> PostOption(Options tilvalg)
        {
          if (_context.Options == null)
          {
              return Problem("Entity set 'Entities.Tilvalg'  is null.");
          }
            _context.Options.Add(tilvalg);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOption", new { id = tilvalg.Id }, tilvalg);
        }

        // DELETE: api/Options/5
        /// <summary>
        /// Deletes specific Component
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            if (_context.Options == null)
            {
                return NotFound();
            }
            var tilvalg = await _context.Options.FindAsync(id);
            if (tilvalg == null)
            {
                return NotFound();
            }

            _context.Options.Remove(tilvalg);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OptionExists(int id)
        {
            return (_context.Options?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
