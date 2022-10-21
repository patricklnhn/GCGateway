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
    public class BuildingController : ControllerBase
    {
        private readonly Entities _context;
        /// <summary>
        /// Contains the Buildings
        /// </summary>
        /// <param name="context"></param>

        public BuildingController(Entities context)
        {
            _context = context;
        }

        // GET: api/Buildings
        /// <summary>
        /// Gets all Buildings
        /// </summary>
        /// <returns>ActionResult IEnumerable Building</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Building>>> GetBuildings()
        {
          if (_context.Buildings == null)
          {
              return NotFound();
          }
            return await _context.Buildings.ToListAsync();
        }

        // GET: api/Buildings/5
        /// <summary>
        /// Gets a specific Building
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult Building</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Building>> GetBuilding(int id)
        {
          if (_context.Buildings == null)
          {
              return NotFound();
          }
            var bygning = await _context.Buildings.FindAsync(id);

            if (bygning == null)
            {
                return NotFound();
            }

            return bygning;
        }

        // PUT: api/Buildings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Building
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bygning"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuilding(int id, Building bygning)
        {
            if (id != bygning.Id)
            {
                return BadRequest();
            }

            _context.Entry(bygning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BygningExists(id))
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

        // POST: api/Buildings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a new Building
        /// </summary>
        /// <param name="bygning"></param>
        /// <returns>ActionResult Building</returns>
        [HttpPost]
        public async Task<ActionResult<Building>> PostBuilding(Building bygning)
        {
          if (_context.Buildings == null)
          {
              return Problem("Entity set 'Entities.Building'  is null.");
          }
            _context.Buildings.Add(bygning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuilding", new { id = bygning.Id }, bygning);
        }

        // DELETE: api/Bygnings/5
        /// <summary>
        /// Deletes a specific Building
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBuilding(int id)
        {
            if (_context.Buildings == null)
            {
                return NotFound();
            }
            var bygning = await _context.Buildings.FindAsync(id);
            if (bygning == null)
            {
                return NotFound();
            }

            _context.Buildings.Remove(bygning);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BygningExists(int id)
        {
            return (_context.Buildings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
