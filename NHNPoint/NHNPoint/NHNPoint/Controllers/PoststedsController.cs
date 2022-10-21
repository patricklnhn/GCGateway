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
    public class PoststedsController : ControllerBase
    {
        private readonly Entities _context;

        /// <summary>
        /// Contains Poststeder
        /// </summary>
        /// <param name="context"></param>

        public PoststedsController(Entities context)
        {
            _context = context;
        }

        // GET: api/Poststeds
        /// <summary>
        /// Gets all Poststeder
        /// </summary>
        /// <returns>ActionResult IEnumerable Poststed</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Poststed>>> GetPoststed()
        {
          if (_context.Poststed == null)
          {
              return NotFound();
          }
            return await _context.Poststed.ToListAsync();
        }

        // GET: api/Poststeds/5
        /// <summary>
        /// Gets a specific Poststed
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult Poststed</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Poststed>> GetPoststed(int id)
        {
          if (_context.Poststed == null)
          {
              return NotFound();
          }
            var poststed = await _context.Poststed.FindAsync(id);

            if (poststed == null)
            {
                return NotFound();
            }

            return poststed;
        }

        // PUT: api/Poststeds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Poststed
        /// </summary>
        /// <param name="id"></param>
        /// <param name="poststed"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPoststed(int id, Poststed poststed)
        {
            if (id != poststed.Id)
            {
                return BadRequest();
            }

            _context.Entry(poststed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PoststedExists(id))
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

        // POST: api/Poststeds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Poststed
        /// </summary>
        /// <param name="poststed"></param>
        /// <returns>ActionResult Poststed</returns>
        [HttpPost]
        public async Task<ActionResult<Poststed>> PostPoststed(Poststed poststed)
        {
          if (_context.Poststed == null)
          {
              return Problem("Entity set 'Entities.Poststed'  is null.");
          }
            _context.Poststed.Add(poststed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPoststed", new { id = poststed.Id }, poststed);
        }

        // DELETE: api/Poststeds/5
        /// <summary>
        /// Deletes a specific Poststed
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePoststed(int id)
        {
            if (_context.Poststed == null)
            {
                return NotFound();
            }
            var poststed = await _context.Poststed.FindAsync(id);
            if (poststed == null)
            {
                return NotFound();
            }

            _context.Poststed.Remove(poststed);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PoststedExists(int id)
        {
            return (_context.Poststed?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
