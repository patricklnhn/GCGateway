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
    public class FylkesController : ControllerBase
    {
        private readonly Entities _context;

        /// <summary>
        /// Contains Fylker
        /// </summary>
        /// <param name="context"></param>

        public FylkesController(Entities context)
        {
            _context = context;
        }

        // GET: api/Fylkes
        /// <summary>
        /// Gets all Fylker
        /// </summary>
        /// <returns>ActionResult IEnumerable Fylke</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fylke>>> GetFylke()
        {
          if (_context.Fylke == null)
          {
              return NotFound();
          }
            return await _context.Fylke.ToListAsync();
        }

        // GET: api/Fylkes/5
        /// <summary>
        /// Gets a specific Fylke
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult Fylke</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Fylke>> GetFylke(int id)
        {
          if (_context.Fylke == null)
          {
              return NotFound();
          }
            var fylke = await _context.Fylke.FindAsync(id);

            if (fylke == null)
            {
                return NotFound();
            }

            return fylke;
        }

        // PUT: api/Fylkes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Fylke
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fylke"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFylke(int id, Fylke fylke)
        {
            if (id != fylke.Id)
            {
                return BadRequest();
            }

            _context.Entry(fylke).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FylkeExists(id))
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

        // POST: api/Fylkes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Fylke
        /// </summary>
        /// <param name="fylke"></param>
        /// <returns>ActionResult Fylke</returns>
        [HttpPost]
        public async Task<ActionResult<Fylke>> PostFylke(Fylke fylke)
        {
          if (_context.Fylke == null)
          {
              return Problem("Entity set 'Entities.Fylke'  is null.");
          }
            _context.Fylke.Add(fylke);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFylke", new { id = fylke.Id }, fylke);
        }

        // DELETE: api/Fylkes/5
        /// <summary>
        /// Deletes a specific Fylke
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFylke(int id)
        {
            if (_context.Fylke == null)
            {
                return NotFound();
            }
            var fylke = await _context.Fylke.FindAsync(id);
            if (fylke == null)
            {
                return NotFound();
            }

            _context.Fylke.Remove(fylke);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FylkeExists(int id)
        {
            return (_context.Fylke?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
