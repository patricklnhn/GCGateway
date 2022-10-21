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
    public class OptionValuesController : ControllerBase
    {
        private readonly Entities _context;

        public OptionValuesController(Entities context)
        {
            _context = context;
        }

        // GET: api/OptionValues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionValues>>> GetOptionValues()
        {
          if (_context.OptionValues == null)
          {
              return NotFound();
          }
            return await _context.OptionValues.ToListAsync();
        }

        // GET: api/OptionValues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OptionValues>> GetOptionValues(int id)
        {
          if (_context.OptionValues == null)
          {
              return NotFound();
          }
            var optionValues = await _context.OptionValues.FindAsync(id);

            if (optionValues == null)
            {
                return NotFound();
            }

            return optionValues;
        }

        // PUT: api/OptionValues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOptionValues(int id, OptionValues optionValues)
        {
            if (id != optionValues.Id)
            {
                return BadRequest();
            }

            _context.Entry(optionValues).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionValuesExists(id))
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

        // POST: api/OptionValues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OptionValues>> PostOptionValues(OptionValues optionValues)
        {
          if (_context.OptionValues == null)
          {
              return Problem("Entity set 'Entities.OptionValues'  is null.");
          }
            _context.OptionValues.Add(optionValues);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOptionValues", new { id = optionValues.Id }, optionValues);
        }

        // DELETE: api/OptionValues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOptionValues(int id)
        {
            if (_context.OptionValues == null)
            {
                return NotFound();
            }
            var optionValues = await _context.OptionValues.FindAsync(id);
            if (optionValues == null)
            {
                return NotFound();
            }

            _context.OptionValues.Remove(optionValues);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OptionValuesExists(int id)
        {
            return (_context.OptionValues?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
