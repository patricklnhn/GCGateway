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
    public class PointsController : ControllerBase
    {
        private readonly Entities _context;
        /// <summary>
        /// Contains the Points
        /// </summary>
        /// <param name="context"></param>

        public PointsController(Entities context)
        {
            _context = context;
        }

        // GET: api/Points
        /// <summary>
        /// Gets all Points
        /// </summary>
        /// <returns>ActionResult IEnumerable Point</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Point>>> GetPoints()
        {
          if (_context.Points == null)
          {
              return NotFound();
          }
            return await _context.Points.ToListAsync();
        }

        // GET: api/Points/5
        /// <summary>
        /// Gets a specific Point
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult Point</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Point>> GetPoint(int id)
        {
          if (_context.Points == null)
          {
              return NotFound();
          }
            var punkt = await _context.Points.FindAsync(id);

            if (punkt == null)
            {
                return NotFound();
            }

            return punkt;
        }

        // PUT: api/Points/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Point
        /// </summary>
        /// <param name="id"></param>
        /// <param name="punkt"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoint(int id, Point punkt)
        {
            if (id != punkt.Id)
            {
                return BadRequest();
            }

            _context.Entry(punkt).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PointExists(id))
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

        // POST: api/Points
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Point
        /// </summary>
        /// <param name="punkt"></param>
        /// <returns>ActionResult Point</returns>
        [HttpPost]
        public async Task<ActionResult<Point>> PostPoint(Point punkt)
        {
          if (_context.Points == null)
          {
              return Problem("Entity set 'Entities.Points'  is null.");
          }
            _context.Points.Add(punkt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoint", new { id = punkt.Id }, punkt);
        }

        // DELETE: api/Points/5
        /// <summary>
        /// Deletes a specific Point
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoint(int id)
        {
            if (_context.Points == null)
            {
                return NotFound();
            }
            var punkt = await _context.Points.FindAsync(id);
            if (punkt == null)
            {
                return NotFound();
            }

            _context.Points.Remove(punkt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PointExists(int id)
        {
            return (_context.Points?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
