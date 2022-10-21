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
    public class ServicesCostAndIncomeController : ControllerBase
    {
        private readonly Entities _context;
        /// <summary>
        /// Contains The Services Costs and Income
        /// </summary>
        /// <param name="context"></param>

        public ServicesCostAndIncomeController(Entities context)
        {
            _context = context;
        }

        // GET: api/ServicesCostAndIncome
        /// <summary>
        /// Gets all Services Costs and Income
        /// </summary>
        /// <returns>ActionResult IEnumerable ServicesCostAndIncome</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicesCostAndIncome>>> GetServicesCostAndIncome()
        {
          if (_context.ServicesCostAndIncome == null)
          {
              return NotFound();
          }
            return await _context.ServicesCostAndIncome.ToListAsync();
        }

        // GET: api/ServicesCostAndIncome/5
        /// <summary>
        /// Gest a specific Service Cost and Income
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult ServicesCostAndIncome</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicesCostAndIncome>> GetServicesCostAndIncome(int id)
        {
          if (_context.ServicesCostAndIncome == null)
          {
              return NotFound();
          }
            var tjenesteKostnaderOgInntekter = await _context.ServicesCostAndIncome.FindAsync(id);

            if (tjenesteKostnaderOgInntekter == null)
            {
                return NotFound();
            }

            return tjenesteKostnaderOgInntekter;
        }

        // PUT: api/ServicesCostAndIncome/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Service Cost and Income
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tjenesteKostnaderOgInntekter"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicesCostAndIncome(int id, ServicesCostAndIncome tjenesteKostnaderOgInntekter)
        {
            if (id != tjenesteKostnaderOgInntekter.Id)
            {
                return BadRequest();
            }

            _context.Entry(tjenesteKostnaderOgInntekter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicesCostAndIncomeExists(id))
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

        // POST: api/ServicesCostAndIncome
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Service Cost and Income
        /// </summary>
        /// <param name="tjenesteKostnaderOgInntekter"></param>
        /// <returns>ActionResult ServicesCostAndIncome</returns>
        [HttpPost]
        public async Task<ActionResult<ServicesCostAndIncome>> PostServicesCostAndIncome(ServicesCostAndIncome tjenesteKostnaderOgInntekter)
        {
          if (_context.ServicesCostAndIncome == null)
          {
              return Problem("Entity set 'Entities.TjenesteKostnaderOgInntekter'  is null.");
          }
            _context.ServicesCostAndIncome.Add(tjenesteKostnaderOgInntekter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicesCostAndIncome", new { id = tjenesteKostnaderOgInntekter.Id }, tjenesteKostnaderOgInntekter);
        }

        //Sletting skal ikke være tilgjengelig for annet enn admin site
        // DELETE: api/ServicesCostAndIncome/5
        /// <summary>
        /// Deletes a specific Service Cost and Income
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServicesCostAndIncome(int id)
        {
            if (_context.ServicesCostAndIncome == null)
            {
                return NotFound();
            }
            var tjenesteKostnaderOgInntekter = await _context.ServicesCostAndIncome.FindAsync(id);
            if (tjenesteKostnaderOgInntekter == null)
            {
                return NotFound();
            }

            _context.ServicesCostAndIncome.Remove(tjenesteKostnaderOgInntekter);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicesCostAndIncomeExists(int id)
        {
            return (_context.ServicesCostAndIncome?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
