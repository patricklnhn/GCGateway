using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GlobalConnectDataDB;

namespace NHNGlobalConnectData.Controllers
{
    /// <summary>
    /// API for storing GlobalConnect data traffic
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class Junta2GcConnectionsController : ControllerBase
    {
        private readonly Entities _context;

        public Junta2GcConnectionsController(Entities context)
        {
            _context = context;
        }

        // GET: api/Junta2GcConnections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Junta2GcConnections>>> GetJunta2GcConnections()
        {
          if (_context.Junta2GcConnections == null)
          {
              return NotFound();
          }
            return await _context.Junta2GcConnections.ToListAsync();
        }

        // GET: api/Junta2GcConnections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Junta2GcConnections>> GetJunta2GcConnections(int id)
        {
          if (_context.Junta2GcConnections == null)
          {
              return NotFound();
          }
            var junta2GcConnections = await _context.Junta2GcConnections.FindAsync(id);

            if (junta2GcConnections == null)
            {
                return NotFound();
            }

            return junta2GcConnections;
        }

        // PUT: api/Junta2GcConnections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJunta2GcConnections(int id, Junta2GcConnections junta2GcConnections)
        {
            if (id != junta2GcConnections.Id)
            {
                return BadRequest();
            }

            _context.Entry(junta2GcConnections).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Junta2GcConnectionsExists(id))
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

        // POST: api/Junta2GcConnections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Junta2GcConnections>> PostJunta2GcConnections(Junta2GcConnections junta2GcConnections)
        {
          if (_context.Junta2GcConnections == null)
          {
              return Problem("Entity set 'Entities.Junta2GcConnections'  is null.");
          }
            _context.Junta2GcConnections.Add(junta2GcConnections);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetJunta2GcConnections", new { id = junta2GcConnections.Id }, junta2GcConnections);
        }

        // DELETE: api/Junta2GcConnections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJunta2GcConnections(int id)
        {
            if (_context.Junta2GcConnections == null)
            {
                return NotFound();
            }
            var junta2GcConnections = await _context.Junta2GcConnections.FindAsync(id);
            if (junta2GcConnections == null)
            {
                return NotFound();
            }

            _context.Junta2GcConnections.Remove(junta2GcConnections);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Junta2GcConnectionsExists(int id)
        {
            return (_context.Junta2GcConnections?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
