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
    public class ServiceInstanceCostAndIncomesController : ControllerBase
    {
        private readonly Entities _context;

        /// <summary>
        /// Contains the ServiceInctance with costs and income
        /// </summary>
        /// <param name="context"></param>
        public ServiceInstanceCostAndIncomesController(Entities context)
        {
            _context = context;
        }

        // GET: api/ServiceInstanceCostAndIncomes
        /// <summary>
        /// Gets all Service Instances with costs and income
        /// </summary>
        /// <returns>ActionResult IEnumerable ServiceInstanceCostAndIncome</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceInstanceCostAndIncome>>> GetServiceInstancesCostAndIncome()
        {
          if (_context.ServiceInstancesCostAndIncome == null)
          {
              return NotFound();
          }
            return await _context.ServiceInstancesCostAndIncome.ToListAsync();
        }

        // GET: api/ServiceInstanceCostAndIncomes/5
        /// <summary>
        /// Gets specific ServiceInstanceCostAndIncome instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceInstanceCostAndIncome>> GetServiceInstanceCostAndIncome(int id)
        {
          if (_context.ServiceInstancesCostAndIncome == null)
          {
              return NotFound();
          }
            var serviceInstanceCostAndIncome = await _context.ServiceInstancesCostAndIncome.FindAsync(id);

            if (serviceInstanceCostAndIncome == null)
            {
                return NotFound();
            }

            return serviceInstanceCostAndIncome;
        }

        // PUT: api/ServiceInstanceCostAndIncomes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific instance of ServiceInstanceCostAndIncome
        /// </summary>
        /// <param name="id"></param>
        /// <param name="serviceInstanceCostAndIncome"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceInstanceCostAndIncome(int id, ServiceInstanceCostAndIncome serviceInstanceCostAndIncome)
        {
            if (id != serviceInstanceCostAndIncome.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceInstanceCostAndIncome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceInstanceCostAndIncomeExists(id))
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

        // POST: api/ServiceInstanceCostAndIncomes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new ServiceInstanceCostAndIncome
        /// </summary>
        /// <param name="serviceInstanceCostAndIncome"></param>
        /// <returns>ActionResult</returns>
        [HttpPost]
        public async Task<ActionResult<ServiceInstanceCostAndIncome>> PostServiceInstanceCostAndIncome(ServiceInstanceCostAndIncome serviceInstanceCostAndIncome)
        {
          if (_context.ServiceInstancesCostAndIncome == null)
          {
              return Problem("Entity set 'Entities.ServiceInstancesCostAndIncome'  is null.");
          }
            _context.ServiceInstancesCostAndIncome.Add(serviceInstanceCostAndIncome);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceInstanceCostAndIncome", new { id = serviceInstanceCostAndIncome.Id }, serviceInstanceCostAndIncome);
        }

        // DELETE: api/ServiceInstanceCostAndIncomes/5
        /// <summary>
        /// Deletes a spcific ServiceInstanceCostAndIncome
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceInstanceCostAndIncome(int id)
        {
            if (_context.ServiceInstancesCostAndIncome == null)
            {
                return NotFound();
            }
            var serviceInstanceCostAndIncome = await _context.ServiceInstancesCostAndIncome.FindAsync(id);
            if (serviceInstanceCostAndIncome == null)
            {
                return NotFound();
            }

            _context.ServiceInstancesCostAndIncome.Remove(serviceInstanceCostAndIncome);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceInstanceCostAndIncomeExists(int id)
        {
            return (_context.ServiceInstancesCostAndIncome?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
