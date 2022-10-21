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
    public class TechnicalStatusController : ControllerBase
    {
        private readonly Entities _context;

        /// <summary>
        /// Contains the technical statuses
        /// </summary>
        /// <param name="context"></param>
        public TechnicalStatusController(Entities context)
        {
            _context = context;
        }

        // GET: api/TechnicalStatus
        /// <summary>
        /// Gets all technical statuses
        /// </summary>
        /// <returns>IEnumerable TechnicalStatus</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TechnicalStatus>>> GetTechnicalStatuses()
        {
          if (_context.TechnicalStatuses == null)
          {
              return NotFound();
          }
            return await _context.TechnicalStatuses.ToListAsync();
        }

        // GET: api/TechnicalStatus/5
        /// <summary>
        /// Gets a specific technical status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TechnicalStatus>> GetTechnicalStatus(int id)
        {
          if (_context.TechnicalStatuses == null)
          {
              return NotFound();
          }
            var technicalStatus = await _context.TechnicalStatuses.FindAsync(id);

            if (technicalStatus == null)
            {
                return NotFound();
            }

            return technicalStatus;
        }

        // PUT: api/TechnicalStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific technical status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="technicalStatus"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTechnicalStatus(int id, TechnicalStatus technicalStatus)
        {
            if (id != technicalStatus.Id)
            {
                return BadRequest();
            }

            _context.Entry(technicalStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TechnicalStatusExists(id))
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

        // POST: api/TechnicalStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        ///  Creates new technical status
        /// </summary>
        /// <param name="technicalStatus"></param>
        /// <returns>ActionResult TechnicalStatus</returns>
        [HttpPost]
        public async Task<ActionResult<TechnicalStatus>> PostTechnicalStatus(TechnicalStatus technicalStatus)
        {
            if (_context.TechnicalStatuses == null)
            {
                return Problem("Entity set 'Entities.TechnicalStatuses'  is null.");
            }
            _context.TechnicalStatuses.Add(technicalStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTechnicalStatus", new { id = technicalStatus.Id }, technicalStatus);
        }

        // DELETE: api/TechnicalStatus/5
        /// <summary>
        /// Deletes a specific technical status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTechnicalStatus(int id)
        {
            if (_context.TechnicalStatuses == null)
            {
                return NotFound();
            }
            var technicalStatus = await _context.TechnicalStatuses.FindAsync(id);
            if (technicalStatus == null)
            {
                return NotFound();
            }

            _context.TechnicalStatuses.Remove(technicalStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TechnicalStatusExists(int id)
        {
            return (_context.TechnicalStatuses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
