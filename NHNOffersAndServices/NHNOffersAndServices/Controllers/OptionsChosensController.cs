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
    public class OptionsChosensController : ControllerBase
    {
        private readonly Entities _context;

        /// <summary>
        /// Contains Options chosen for service instances 
        /// </summary>
        /// <param name="context"></param>
        public OptionsChosensController(Entities context)
        {
            _context = context;
        }

        // GET: api/OptionsChosens
        /// <summary>
        /// Gets all Options chosen
        /// </summary>
        /// <returns>ActionResult IEnumerable OptionsChosen</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OptionsChosen>>> GetOptionsChosen()
        {
          if (_context.OptionsChosen == null)
          {
              return NotFound();
          }
            return await _context.OptionsChosen.ToListAsync();
        }

        // GET: api/OptionsChosens/5
        /// <summary>
        /// Gets a specific option chosen 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult OptionsChosen</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<OptionsChosen>> GetOptionsChosen(int id)
        {
          if (_context.OptionsChosen == null)
          {
              return NotFound();
          }
            var optionsChosen = await _context.OptionsChosen.FindAsync(id);

            if (optionsChosen == null)
            {
                return NotFound();
            }

            return optionsChosen;
        }

        // PUT: api/OptionsChosens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific option chosen
        /// </summary>
        /// <param name="id"></param>
        /// <param name="optionsChosen"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOptionsChosen(int id, OptionsChosen optionsChosen)
        {
            if (id != optionsChosen.Id)
            {
                return BadRequest();
            }

            _context.Entry(optionsChosen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OptionsChosenExists(id))
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

        // POST: api/OptionsChosens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new option chosen
        /// </summary>
        /// <param name="optionsChosen"></param>
        /// <returns>ActionResult OptionsChosen</returns>
        [HttpPost]
        public async Task<ActionResult<OptionsChosen>> PostOptionsChosen(OptionsChosen optionsChosen)
        {
          if (_context.OptionsChosen == null)
          {
              return Problem("Entity set 'Entities.OptionsChosen'  is null.");
          }
            _context.OptionsChosen.Add(optionsChosen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOptionsChosen", new { id = optionsChosen.Id }, optionsChosen);
        }

        // DELETE: api/OptionsChosens/5
        /// <summary>
        /// Deletes specific option chosen
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOptionsChosen(int id)
        {
            if (_context.OptionsChosen == null)
            {
                return NotFound();
            }
            var optionsChosen = await _context.OptionsChosen.FindAsync(id);
            if (optionsChosen == null)
            {
                return NotFound();
            }

            _context.OptionsChosen.Remove(optionsChosen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OptionsChosenExists(int id)
        {
            return (_context.OptionsChosen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
