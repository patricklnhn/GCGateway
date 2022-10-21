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
    public class ServiceComponentsController : ControllerBase
    {
        private readonly Entities _context;
        /// <summary>
        /// Contains The Service Components
        /// </summary>
        /// <param name="context"></param>

        public ServiceComponentsController(Entities context)
        {
            _context = context;
        }

        // GET: api/ServicesComponents
        /// <summary>
        /// Gets all the Service Components
        /// </summary>
        /// <returns>ActionResult IEnumerable ServicesComponents</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicesComponents>>> GetServiceComponents()
        {
          if (_context.ServicesComponents == null)
          {
              return NotFound();
          }
            return await _context.ServicesComponents.ToListAsync();
        }

        // GET: api/ServicesComponents/5
        /// <summary>
        /// Gets a specific Service Component
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult ServicesComponents</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicesComponents>> GetServiceComponent(int id)
        {
          if (_context.ServicesComponents == null)
          {
              return NotFound();
          }
            var tjenesteKomponent = await _context.ServicesComponents.FindAsync(id);

            if (tjenesteKomponent == null)
            {
                return NotFound();
            }

            return tjenesteKomponent;
        }

        // PUT: api/ServicesComponents/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Service Component
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tjenesteKomponent"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceComponent(int id, ServicesComponents tjenesteKomponent)
        {
            if (id != tjenesteKomponent.Id)
            {
                return BadRequest();
            }

            _context.Entry(tjenesteKomponent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceComponentExists(id))
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

        // POST: api/ServicesComponents
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Service Component
        /// </summary>
        /// <param name="tjenesteKomponent"></param>
        /// <returns>ActionResult ServicesComponents</returns>
        [HttpPost]
        public async Task<ActionResult<ServicesComponents>> PostServiceComponent(ServicesComponents tjenesteKomponent)
        {
          if (_context.ServicesComponents == null)
          {
              return Problem("Entity set 'Entities.TjenesteKomponent'  is null.");
          }
            _context.ServicesComponents.Add(tjenesteKomponent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceComponent", new { id = tjenesteKomponent.Id }, tjenesteKomponent);
        }

        // DELETE: api/ServicesComponents/5
        /// <summary>
        /// Deletes a specific Service Component
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceComponent(int id)
        {
            if (_context.ServicesComponents == null)
            {
                return NotFound();
            }
            var tjenesteKomponent = await _context.ServicesComponents.FindAsync(id);
            if (tjenesteKomponent == null)
            {
                return NotFound();
            }

            _context.ServicesComponents.Remove(tjenesteKomponent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceComponentExists(int id)
        {
            return (_context.ServicesComponents?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
