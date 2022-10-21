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
    public class ServiceInstancesController : ControllerBase
    {
        private readonly Entities _context;

        /// <summary>
        /// Contains the ServiceInstances
        /// </summary>
        /// <param name="context"></param>
        public ServiceInstancesController(Entities context)
        {
            _context = context;
        }

        // GET: api/ServiceInstances
        /// <summary>
        /// Gets all ServiceInstances
        /// </summary>
        /// <returns>ActionResult IEnumerable ServiceInstance</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceInstance>>> GetServiceInstances()
        {
          if (_context.ServiceInstances == null)
          {
              return NotFound();
          }
            return await _context.ServiceInstances.ToListAsync();
        }

        // GET: api/ServiceInstances/5
        /// <summary>
        /// Gets a specific ServiceInstance 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ServiceInstance</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceInstance>> GetServiceInstance(int id)
        {
          if (_context.ServiceInstances == null)
          {
              return NotFound();
          }
            var serviceInstance = await _context.ServiceInstances.FindAsync(id);

            if (serviceInstance == null)
            {
                return NotFound();
            }

            return serviceInstance;
        }

        // PUT: api/ServiceInstances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Service Instance
        /// </summary>
        /// <param name="id"></param>
        /// <param name="serviceInstance"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceInstance(int id, ServiceInstance serviceInstance)
        {
            if (id != serviceInstance.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceInstance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceInstanceExists(id))
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

        // POST: api/ServiceInstances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates a new Service Instance
        /// </summary>
        /// <param name="serviceInstance"></param>
        /// <returns>ActionResult ServiceInstance</returns>
        [HttpPost]
        public async Task<ActionResult<ServiceInstance>> PostServiceInstance(ServiceInstance serviceInstance)
        {
          if (_context.ServiceInstances == null)
          {
              return Problem("Entity set 'Entities.ServiceInstances'  is null.");
          }
            _context.ServiceInstances.Add(serviceInstance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceInstance", new { id = serviceInstance.Id }, serviceInstance);
        }

        // DELETE: api/ServiceInstances/5
        /// <summary>
        /// Deletes a specific Service Instance
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceInstance(int id)
        {
            if (_context.ServiceInstances == null)
            {
                return NotFound();
            }
            var serviceInstance = await _context.ServiceInstances.FindAsync(id);
            if (serviceInstance == null)
            {
                return NotFound();
            }

            _context.ServiceInstances.Remove(serviceInstance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceInstanceExists(int id)
        {
            return (_context.ServiceInstances?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
