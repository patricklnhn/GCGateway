using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OffersAndServicesDatabase;

namespace NHNOffersAndServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MercantileStatusController : ControllerBase
    {
        private readonly Entities _context;

        /// <summary>
        /// Contains the mercantile statuses
        /// </summary>
        /// <param name="context"></param>
        public MercantileStatusController(Entities context)
        {
            _context = context;
        }

        // GET: api/MercantileStatus
        /// <summary>
        /// Gets all Mercatile statuses
        /// </summary>
        /// <returns>ActionResult IEnumerable MercantileStatus </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MercantileStatus>>> GetMercantileStatuses()
        {
          if (_context.MercantileStatuses == null)
          {
              return NotFound();
          }
            return await _context.MercantileStatuses.ToListAsync();
        }

        // GET: api/MercantileStatus/5
        /// <summary>
        /// Returns specific Mercatile status
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult MercantileStatus</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MercantileStatus>> GetMercantileStatus(int id)
        {
          if (_context.MercantileStatuses == null)
          {
              return NotFound();
          }
            var mercantileStatus = await _context.MercantileStatuses.FindAsync(id);

            if (mercantileStatus == null)
            {
                return NotFound();
            }

            return mercantileStatus;
        }

        // PUT: api/MercantileStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// For posting update to a single Mercatile status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="mercantileStatus"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMercantileStatus(int id, MercantileStatus mercantileStatus)
        {
            if (id != mercantileStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(mercantileStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MercantileStatusExists(id))
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

        // POST: api/MercantileStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Mercatile status
        /// </summary>
        /// <param name="mercantileStatus"></param>
        /// <returns>ActionResult MercantileStatus</returns>
        [HttpPost]
        public async Task<ActionResult<MercantileStatus>> PostMercantileStatus(MercantileStatus mercantileStatus)
        {
          if (_context.MercantileStatuses == null)
          {
              return Problem("Entity set 'Entities.MercantileStatuses'  is null.");
          }
            _context.MercantileStatuses.Add(mercantileStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMercantileStatus", new { id = mercantileStatus.Id }, mercantileStatus);
        }

        // DELETE: api/MercantileStatus/5
        /// <summary>
        /// Deletes specific Mercantile status
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMercantileStatus(int id)
        {
            if (_context.MercantileStatuses == null)
            {
                return NotFound();
            }
            var mercantileStatus = await _context.MercantileStatuses.FindAsync(id);
            if (mercantileStatus == null)
            {
                return NotFound();
            }

            _context.MercantileStatuses.Remove(mercantileStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MercantileStatusExists(int id)
        {
            return (_context.MercantileStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
