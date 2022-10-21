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
    public class OptionsCostController : ControllerBase
    {
        private readonly Entities _context;

        /// <summary>
        /// Contains the OptionsCosts
        /// </summary>
        /// <param name="context"></param>
        public OptionsCostController(Entities context)
        {
            _context = context;
        }

        // GET: api/OptionsCosts
        /// <summary>
        /// Gets all Options Costs
        /// </summary>
        /// <returns>ActionResult IEnumerable OptionsCosts</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionsCosts>>> GetOptionsCosts()
        {
          if (_context.OptionsCosts == null)
          {
              return NotFound();
          }
            return await _context.OptionsCosts.ToListAsync();
        }

        // GET: api/OptionsCosts/5
        /// <summary>
        /// Gets a specific Options Cost
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult OptionsCosts</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OptionsCosts>> GetOptionsCost(int id)
        {
          if (_context.OptionsCosts == null)
          {
              return NotFound();
          }
            var tilvalgKostnader = await _context.OptionsCosts.FindAsync(id);

            if (tilvalgKostnader == null)
            {
                return NotFound();
            }

            return tilvalgKostnader;
        }

        // PUT: api/OptionsCosts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specfic Options Cost
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tilvalgKostnader"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOptionsCost(int id, OptionsCosts tilvalgKostnader)
        {
            if (id != tilvalgKostnader.Id)
            {
                return BadRequest();
            }

            _context.Entry(tilvalgKostnader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionsCostExists(id))
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

        // POST: api/OptionsCosts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Options Cost
        /// </summary>
        /// <param name="tilvalgKostnader"></param>
        /// <returns>ActionResult OptionsCosts</returns>
        [HttpPost]
        public async Task<ActionResult<OptionsCosts>> PostOptionsCost(OptionsCosts tilvalgKostnader)
        {
          if (_context.OptionsCosts == null)
          {
              return Problem("Entity set 'Entities.OptionsCost'  is null.");
          }
            _context.OptionsCosts.Add(tilvalgKostnader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOptionsCost", new { id = tilvalgKostnader.Id }, tilvalgKostnader);
        }

        // DELETE: api/OptionsCosts/5
        /// <summary>
        /// Deletes specific Options Cost
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOptionsCost(int id)
        {
            if (_context.OptionsCosts == null)
            {
                return NotFound();
            }
            var tilvalgKostnader = await _context.OptionsCosts.FindAsync(id);
            if (tilvalgKostnader == null)
            {
                return NotFound();
            }

            _context.OptionsCosts.Remove(tilvalgKostnader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OptionsCostExists(int id)
        {
            return (_context.OptionsCosts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
