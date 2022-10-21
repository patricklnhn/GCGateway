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
    public class AddressController : ControllerBase
    {
        private readonly Entities _context;
        private readonly ILogger _logger;

        /// <summary>
        /// Contains the Addresses
        /// </summary>
        /// <param name="context"></param>
        public AddressController(Entities context, ILogger<AddressController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/Addresses
        /// <summary>
        /// Gets all Adresses
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Address>>> GetAddresses()
        {
          if (_context.Addresses == null)
          {
              return NotFound();
          }
            return await _context.Addresses.ToListAsync();
        }

        // GET: api/Addresses/5
        /// <summary>
        /// Gets a specific Address
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult Address</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Address>> GetAddress(int id)
        {
          if (_context.Addresses == null)
          {
              return NotFound();
          }
            var adresse = await _context.Addresses.FindAsync(id);

            if (adresse == null)
            {
                return NotFound();
            }

            return adresse;
        }

        // PUT: api/Addresses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Address
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adresse"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddress(int id, Address adresse)
        {
            if (id != adresse.Id)
            {
                return BadRequest();
            }

            _context.Entry(adresse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddressExists(id))
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

        // POST: api/Addresses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Address
        /// </summary>
        /// <param name="adresse"></param>
        /// <returns>ActionResult Address</returns>
        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address adresse)
        {
          if (_context.Addresses == null)
          {
              return Problem("Entity set 'Entities.Addresses'  is null.");
          }
            _context.Addresses.Add(adresse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = adresse.Id }, adresse);
        }

        // DELETE: api/Addresses/5
        /// <summary>
        /// Deletes a specific Address
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (_context.Addresses == null)
            {
                return NotFound();
            }
            var adresse = await _context.Addresses.FindAsync(id);
            if (adresse == null)
            {
                return NotFound();
            }

            _context.Addresses.Remove(adresse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddressExists(int id)
        {
            return (_context.Addresses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
