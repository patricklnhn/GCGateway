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
    public class ServiceController : ControllerBase
    {
        private readonly Entities _context;
        /// <summary>
        /// Contains The Services
        /// </summary>
        /// <param name="context"></param>

        public ServiceController(Entities context)
        {
            _context = context;
        }

        // GET: api/Service
        /// <summary>
        /// Gets all Services
        /// </summary>
        /// <returns>ActionResult IEnumerable Services</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Services>>> GetServices()
        {
          if (_context.Services == null)
          {
              return NotFound();
          }
            return await _context.Services.ToListAsync();
        }

        // GET: api/Service/5
        /// <summary>
        /// Gets a specific Service
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult Services</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Services>> GetService(int id)
        {
          if (_context.Services == null)
          {
              return NotFound();
          }
            var tjeneste = await _context.Services.FindAsync(id);

            if (tjeneste == null)
            {
                return NotFound();
            }

            return tjeneste;
        }

        // PUT: api/Service/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Service
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tjeneste"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, Services tjeneste)
        {
            if (id != tjeneste.Id)
            {
                return BadRequest();
            }

            _context.Entry(tjeneste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id))
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

        // POST: api/Service
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Service
        /// </summary>
        /// <param name="tjeneste"></param>
        /// <returns>ActionResult Services</returns>
        [HttpPost]
        public async Task<ActionResult<Services>> PostService(Services tjeneste)
        {
          if (_context.Services == null)
          {
              return Problem("Entity set 'Entities.Service'  is null.");
          }
            _context.Services.Add(tjeneste);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetService", new { id = tjeneste.Id }, tjeneste);
        }

        // DELETE: api/Service/5
        /// <summary>
        /// Deletes a specific Service
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            if (_context.Services == null)
            {
                return NotFound();
            }
            var tjeneste = await _context.Services.FindAsync(id);
            if (tjeneste == null)
            {
                return NotFound();
            }

            _context.Services.Remove(tjeneste);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(int id)
        {
            return (_context.Services?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
