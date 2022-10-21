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
    public class OptionsPerServiceController : ControllerBase
    {
        private readonly Entities _context;
        /// <summary>
        /// Contains Options Per Service
        /// </summary>
        /// <param name="context"></param>

        public OptionsPerServiceController(Entities context)
        {
            _context = context;
        }

        // GET: api/OptionsPerService
        /// <summary>
        /// Gets all Options Per Service
        /// </summary>
        /// <returns>ActionResult IEnumerable OptionsPerService</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionsPerService>>> GetOptionsPerServices()
        {
          if (_context.OptionsPerServices == null)
          {
              return NotFound();
          }
            return await _context.OptionsPerServices.ToListAsync();
        }

        // GET: api/OptionsPerService/5
        /// <summary>
        /// Gets a specific Option Per Service
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult OptionsPerService</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OptionsPerService>> GetOptionsPerService(int id)
        {
          if (_context.OptionsPerServices == null)
          {
              return NotFound();
          }
            var tilvalgPrTjeneste = await _context.OptionsPerServices.FindAsync(id);

            if (tilvalgPrTjeneste == null)
            {
                return NotFound();
            }

            return tilvalgPrTjeneste;
        }

        // PUT: api/OptionsPerService/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Option Per Service
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tilvalgPrTjeneste"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOptionsPerService(int id, OptionsPerService tilvalgPrTjeneste)
        {
            if (id != tilvalgPrTjeneste.Id)
            {
                return BadRequest();
            }

            _context.Entry(tilvalgPrTjeneste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionsPerServiceExists(id))
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

        // POST: api/OptionsPerService
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Option Per Service
        /// </summary>
        /// <param name="tilvalgPrTjeneste"></param>
        /// <returns>ActionResult OptionsPerService</returns>
        [HttpPost]
        public async Task<ActionResult<OptionsPerService>> PostOptionsPerService(OptionsPerService tilvalgPrTjeneste)
        {
          if (_context.OptionsPerServices == null)
          {
              return Problem("Entity set 'Entities.OptionsPerService'  is null.");
          }
            _context.OptionsPerServices.Add(tilvalgPrTjeneste);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOptionsPerService", new { id = tilvalgPrTjeneste.Id }, tilvalgPrTjeneste);
        }

        // DELETE: api/OptionsPerService/5
        /// <summary>
        /// Deletes a specific Option Per Service
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOptionsPerService(int id)
        {
            if (_context.OptionsPerServices == null)
            {
                return NotFound();
            }
            var tilvalgPrTjeneste = await _context.OptionsPerServices.FindAsync(id);
            if (tilvalgPrTjeneste == null)
            {
                return NotFound();
            }

            _context.OptionsPerServices.Remove(tilvalgPrTjeneste);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OptionsPerServiceExists(int id)
        {
            return (_context.OptionsPerServices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
