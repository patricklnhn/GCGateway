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
    public class ComponentsController : ControllerBase
    {
        private readonly Entities _context;

        /// <summary>
        /// Contains the Components
        /// </summary>
        /// <param name="context"></param>
        public ComponentsController(Entities context)
        {
            _context = context;
        }

        // GET: api/Komponent
        /// <summary>
        /// Gets all Components
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Component>>> GetComponents()
        {
          if (_context.Components == null)
          {
              return NotFound();
          }
            return await _context.Components.ToListAsync();
        }

        // GET: api/Komponent/5
        /// <summary>
        /// Gets a specific Component
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult Component</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Component>> GetComponent(int id)
        {
          if (_context.Components == null)
          {
              return NotFound();
          }
            var komponent = await _context.Components.FindAsync(id);

            if (komponent == null)
            {
                return NotFound();
            }

            return komponent;
        }

        // PUT: api/Komponent/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Component
        /// </summary>
        /// <param name="id"></param>
        /// <param name="komponent"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponent(int id, Component komponent)
        {
            if (id != komponent.Id)
            {
                return BadRequest();
            }

            _context.Entry(komponent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentExists(id))
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

        // POST: api/Komponent
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Component
        /// </summary>
        /// <param name="komponent"></param>
        /// <returns>ActionResult Component</returns>
        [HttpPost]
        public async Task<ActionResult<Component>> PostComponent(Component komponent)
        {
          if (_context.Components == null)
          {
              return Problem("Entity set 'Entities.Komponent'  is null.");
          }
            _context.Components.Add(komponent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponent", new { id = komponent.Id }, komponent);
        }

        // DELETE: api/Komponent/5
        /// <summary>
        /// Deletes specific Component
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponent(int id)
        {
            if (_context.Components == null)
            {
                return NotFound();
            }
            var komponent = await _context.Components.FindAsync(id);
            if (komponent == null)
            {
                return NotFound();
            }

            _context.Components.Remove(komponent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponentExists(int id)
        {
            return (_context.Components?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
