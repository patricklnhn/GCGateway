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
    public class ComponentCostsController : ControllerBase
    {
        private readonly Entities _context;

        /// <summary>
        /// Contains The Component Cost
        /// </summary>
        /// <param name="context"></param>
        public ComponentCostsController(Entities context)
        {
            _context = context;
        }

        // GET: api/KomponentKostnader
        /// <summary>
        /// Gets all Component Costs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponentCost>>> GetComponentCosts()
        {
          if (_context.ComponentCosts == null)
          {
              return NotFound();
          }
            return await _context.ComponentCosts.ToListAsync();
        }

        // GET: api/KomponentKostnader/5
        /// <summary>
        /// Gets specific Component Cost
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentCost>> GetComponentCost(int id)
        {
          if (_context.ComponentCosts == null)
          {
              return NotFound();
          }
            var komponentKostnader = await _context.ComponentCosts.FindAsync(id);

            if (komponentKostnader == null)
            {
                return NotFound();
            }

            return komponentKostnader;
        }

        // PUT: api/KomponentKostnader/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Component Cost
        /// </summary>
        /// <param name="id"></param>
        /// <param name="komponentKostnader"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponentCost(int id, ComponentCost komponentKostnader)
        {
            if (id != komponentKostnader.Id)
            {
                return BadRequest();
            }

            _context.Entry(komponentKostnader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentCostExists(id))
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

        // POST: api/KomponentKostnader
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Component Cost
        /// </summary>
        /// <param name="komponentKostnader"></param>
        /// <returns>ActionResult ComponentCost</returns>
        [HttpPost]
        public async Task<ActionResult<ComponentCost>> PostComponentCost(ComponentCost komponentKostnader)
        {
          if (_context.ComponentCosts == null)
          {
              return Problem("Entity set 'Entities.ComponentCost'  is null.");
          }
            _context.ComponentCosts.Add(komponentKostnader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponentCost", new { id = komponentKostnader.Id }, komponentKostnader);
        }

        // DELETE: api/KomponentKostnader/5
        /// <summary>
        /// Deletes specific Component Cost
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponentCost(int id)
        {
            if (_context.ComponentCosts == null)
            {
                return NotFound();
            }
            var komponentKostnader = await _context.ComponentCosts.FindAsync(id);
            if (komponentKostnader == null)
            {
                return NotFound();
            }

            _context.ComponentCosts.Remove(komponentKostnader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponentCostExists(int id)
        {
            return (_context.ComponentCosts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
