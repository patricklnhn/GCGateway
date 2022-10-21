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
    public class HealthRegionController : ControllerBase
    {
        private readonly Entities _context;
        /// <summary>
        /// Contains Health Regions
        /// </summary>
        /// <param name="context"></param>

        public HealthRegionController(Entities context)
        {
            _context = context;
        }

        // GET: api/HealthRegions

        /// <summary>
        /// Gets all Healt Regions
        /// </summary>
        /// <returns>ActionResult IEnumerable HealthRegion</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HealthRegion>>> GetHealthRegions()
        {
          if (_context.HealthRegions == null)
          {
              return NotFound();
          }
            return await _context.HealthRegions.ToListAsync();
        }

        // GET: api/HealthRegions/5
        /// <summary>
        /// Gets a specific Health Region
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult HealthRegion</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<HealthRegion>> GetHealthRegion(int id)
        {
          if (_context.HealthRegions == null)
          {
              return NotFound();
          }
            var helseRegion = await _context.HealthRegions.FindAsync(id);

            if (helseRegion == null)
            {
                return NotFound();
            }

            return helseRegion;
        }

        // PUT: api/HealthRegions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Health Region
        /// </summary>
        /// <param name="id"></param>
        /// <param name="helseRegion"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHealthRegion(int id, HealthRegion helseRegion)
        {
            if (id != helseRegion.Id)
            {
                return BadRequest();
            }

            _context.Entry(helseRegion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HealthRegionExists(id))
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

        // POST: api/HealthRegions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Healt Region
        /// </summary>
        /// <param name="helseRegion"></param>
        /// <returns>ActionResult HealthRegion</returns>
        [HttpPost]
        public async Task<ActionResult<HealthRegion>> PostHealthRegion(HealthRegion helseRegion)
        {
          if (_context.HealthRegions == null)
          {
              return Problem("Entity set 'Entities.HealthRegions'  is null.");
          }
            _context.HealthRegions.Add(helseRegion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHealthRegion", new { id = helseRegion.Id }, helseRegion);
        }

        // DELETE: api/HealthRegions/5
        /// <summary>
        /// Deletes specific Healt Region
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHealthRegion(int id)
        {
            if (_context.HealthRegions == null)
            {
                return NotFound();
            }
            var helseRegion = await _context.HealthRegions.FindAsync(id);
            if (helseRegion == null)
            {
                return NotFound();
            }

            _context.HealthRegions.Remove(helseRegion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HealthRegionExists(int id)
        {
            return (_context.HealthRegions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
