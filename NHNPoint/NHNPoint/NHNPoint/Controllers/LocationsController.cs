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
    public class LocationsController : ControllerBase
    {
        private readonly Entities _context;
        /// <summary>
        /// Contains the Locations
        /// </summary>
        /// <param name="context"></param>

        public LocationsController(Entities context)
        {
            _context = context;
        }

        // GET: api/Locations
        /// <summary>
        /// Gets all Locations
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocations()
        {
          if (_context.Locations == null)
          {
              return NotFound();
          }
            return await _context.Locations.ToListAsync();
        }

        // GET: api/Locations/5
        /// <summary>
        /// Gets a specific Location
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetLocation(int id)
        {
          if (_context.Locations == null)
          {
              return NotFound();
          }
            var lokasjon = await _context.Locations.FindAsync(id);

            if (lokasjon == null)
            {
                return NotFound();
            }

            return lokasjon;
        }

        // PUT: api/Locations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Location
        /// </summary>
        /// <param name="id"></param>
        /// <param name="lokasjon"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocation(int id, Location lokasjon)
        {
            if (id != lokasjon.Id)
            {
                return BadRequest();
            }

            _context.Entry(lokasjon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationExists(id))
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

        // POST: api/Locations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Location
        /// </summary>
        /// <param name="lokasjon"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Location>> PostLocation(Location lokasjon)
        {
          if (_context.Locations == null)
          {
              return Problem("Entity set 'Entities.Locations'  is null.");
          }
            _context.Locations.Add(lokasjon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocation", new { id = lokasjon.Id }, lokasjon);
        }

        // DELETE: api/Locations/5
        /// <summary>
        /// Deletes a specific Location
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            if (_context.Locations == null)
            {
                return NotFound();
            }
            var lokasjon = await _context.Locations.FindAsync(id);
            if (lokasjon == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(lokasjon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocationExists(int id)
        {
            return (_context.Locations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
