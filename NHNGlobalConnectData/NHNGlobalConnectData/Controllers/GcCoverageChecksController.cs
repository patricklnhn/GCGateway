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
    [Route("api/[controller]")]
    [ApiController]
    public class GcCoverageChecksController : ControllerBase
    {
        private readonly Entities _context;

        public GcCoverageChecksController(Entities context)
        {
            _context = context;
        }

        // GET: api/GcCoverageChecks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GcCoverageCheck>>> GetGcCoverageCheck()
        {
          if (_context.GcCoverageCheck == null)
          {
              return NotFound();
          }
            return await _context.GcCoverageCheck.ToListAsync();
        }

        // GET: api/GcCoverageChecks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GcCoverageCheck>> GetGcCoverageCheck(int id)
        {
          if (_context.GcCoverageCheck == null)
          {
              return NotFound();
          }
            var gcCoverageCheck = await _context.GcCoverageCheck.FindAsync(id);

            if (gcCoverageCheck == null)
            {
                return NotFound();
            }

            return gcCoverageCheck;
        }

        // PUT: api/GcCoverageChecks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGcCoverageCheck(int id, GcCoverageCheck gcCoverageCheck)
        {
            if (id != gcCoverageCheck.Id)
            {
                return BadRequest();
            }

            _context.Entry(gcCoverageCheck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GcCoverageCheckExists(id))
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

        // POST: api/GcCoverageChecks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GcCoverageCheck>> PostGcCoverageCheck(GcCoverageCheck gcCoverageCheck)
        {
          if (_context.GcCoverageCheck == null)
          {
              return Problem("Entity set 'Entities.GcCoverageCheck'  is null.");
          }
            _context.GcCoverageCheck.Add(gcCoverageCheck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGcCoverageCheck", new { id = gcCoverageCheck.Id }, gcCoverageCheck);
        }

        // DELETE: api/GcCoverageChecks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGcCoverageCheck(int id)
        {
            if (_context.GcCoverageCheck == null)
            {
                return NotFound();
            }
            var gcCoverageCheck = await _context.GcCoverageCheck.FindAsync(id);
            if (gcCoverageCheck == null)
            {
                return NotFound();
            }

            _context.GcCoverageCheck.Remove(gcCoverageCheck);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GcCoverageCheckExists(int id)
        {
            return (_context.GcCoverageCheck?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
