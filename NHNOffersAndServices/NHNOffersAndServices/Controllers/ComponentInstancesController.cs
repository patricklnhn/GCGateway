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
    public class ComponentInstancesController : ControllerBase
    {
        private readonly Entities _context;
        private readonly ILogger _logger;
        /// <summary>
        /// Contains the ComponentInstances
        /// </summary>
        /// <param name="context"></param>
        /// /// <param name="logger"></param>
        public ComponentInstancesController(Entities context, ILogger<ComponentInstancesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/ComponentInstances
        /// <summary>
        /// Gets all ComponentInstances
        /// </summary>
        /// <returns>IEnumerable<ComponentInstance></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComponentInstance>>> GetComponentInstances()
        {
            
            _logger.LogInformation("GetComponentInstances", DateTime.Now.ToString());
          if (_context.ComponentInstances == null)
          {
                _logger.LogInformation("GetComponentInstances, DataBase Not found", DateTime.Now.ToString().ToString());
              return NotFound();
          }
            return await _context.ComponentInstances.ToListAsync();
        }

        // GET: api/ComponentInstances/5
        /// <summary>
        /// Gets specific ComponentInstance
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ComponentInstance</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ComponentInstance>> GetComponentInstance(int id)
        {
          if (_context.ComponentInstances == null)
          {
                _logger.LogInformation("GetComponentInstances id:"+ id.ToString()+ " , Database Not found", DateTime.Now.ToString().ToString());

                return NotFound();
          }
            var componentInstance = await _context.ComponentInstances.FindAsync(id);

            if (componentInstance == null)
            {
                _logger.LogInformation("GetComponentInstances id:" + id.ToString() + " , No data found", DateTime.Now.ToString().ToString());

                return NotFound();
            }

            return componentInstance;
        }

        // PUT: api/ComponentInstances/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// For posting update to a single ComponentInstance 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="componentInstance"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComponentInstance(int id, ComponentInstance componentInstance)
        {
            if (id != componentInstance.Id)
            {
                return BadRequest();
            }

            _context.Entry(componentInstance).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComponentInstanceExists(id))
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

        // POST: api/ComponentInstances
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creating new ComponentInstance
        /// </summary>
        /// <param name="componentInstance"></param>
        /// <returns>ComponentInstance</returns>
        [HttpPost]
        public async Task<ActionResult<ComponentInstance>> PostComponentInstance(ComponentInstance componentInstance)
        {
          if (_context.ComponentInstances == null)
          {
              return Problem("Entity set 'Entities.ComponentInstances'  is null.");
          }
            _context.ComponentInstances.Add(componentInstance);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComponentInstance", new { id = componentInstance.Id }, componentInstance);
        }

        // DELETE: api/ComponentInstances/5
        /// <summary>
        /// Deletes specific ComponentInstance
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComponentInstance(int id)
        {
            if (_context.ComponentInstances == null)
            {
                return NotFound();
            }
            var componentInstance = await _context.ComponentInstances.FindAsync(id);
            if (componentInstance == null)
            {
                return NotFound();
            }

            _context.ComponentInstances.Remove(componentInstance);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComponentInstanceExists(int id)
        {
            return (_context.ComponentInstances?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
