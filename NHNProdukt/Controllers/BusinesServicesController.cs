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
    public class BusinesServicesController : ControllerBase
    {
        private readonly Entities _context;

        /// <summary>
        /// Contains the BusinesService
        /// </summary>
        /// <param name="context"></param>
        public BusinesServicesController(Entities context)
        {
            _context = context;
        }

        // GET: api/Forretningstjeneste
        /// <summary>
        /// Gets all BusinesServices
        /// </summary>
        /// <returns>ActionResult IEnumerable BusinesService</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinesService>>> GetBusinesServices()
        {
          if (_context.BusinesServices == null)
          {
              return NotFound();
          }
            return await _context.BusinesServices.ToListAsync();
        }

        // GET: api/Forretningstjeneste/5
        /// <summary>
        /// Gets a specific BusinesServise
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult BusinesService</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinesService>> GetBusinesService(int id)
        {
          if (_context.BusinesServices == null)
          {
              return NotFound();
          }
            var forretningstjeneste = await _context.BusinesServices.FindAsync(id);

            if (forretningstjeneste == null)
            {
                return NotFound();
            }

            return forretningstjeneste;
        }

        // PUT: api/Forretningstjeneste/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific BusinesService
        /// </summary>
        /// <param name="id"></param>
        /// <param name="forretningstjeneste"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusinesService(int id, BusinesService forretningstjeneste)
        {
            if (id != forretningstjeneste.Id)
            {
                return BadRequest();
            }

            _context.Entry(forretningstjeneste).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinesServiceExists(id))
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

        // POST: api/Forretningstjeneste
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new BusinesService
        /// </summary>
        /// <param name="forretningstjeneste"></param>
        /// <returns>ActionResult BusinesService</returns>
        [HttpPost]
        public async Task<ActionResult<BusinesService>> PostBusinesService(BusinesService forretningstjeneste)
        {
          if (_context.BusinesServices == null)
          {
              return Problem("Entity set 'Entities.BusinesService'  is null.");
          }
            _context.BusinesServices.Add(forretningstjeneste);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinesService", new { id = forretningstjeneste.Id }, forretningstjeneste);
        }

        // DELETE: api/Forretningstjeneste/5
        /// <summary>
        /// Deletes specific BusinesService
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusinesService(int id)
        {
            if (_context.BusinesServices == null)
            {
                return NotFound();
            }
            var forretningstjeneste = await _context.BusinesServices.FindAsync(id);
            if (forretningstjeneste == null)
            {
                return NotFound();
            }

            _context.BusinesServices.Remove(forretningstjeneste);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusinesServiceExists(int id)
        {
            return (_context.BusinesServices?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
