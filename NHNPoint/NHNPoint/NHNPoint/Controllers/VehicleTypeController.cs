using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PointDatabase;

namespace NHNPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleTypeController : ControllerBase
    {
        private readonly Entities _context;

        /// <summary>
        /// Contains the Vehicle Types
        /// </summary>
        /// <param name="context"></param>

        public VehicleTypeController(Entities context)
        {
            _context = context;
        }

        // GET: api/VehicleTypes
        /// <summary>
        /// Gets all Vehicle Types
        /// </summary>
        /// <returns>ActionResult IEnumerable VehicleType</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VehicleType>>> GetVehicleTypes()
        {
          if (_context.VehicleTypes == null)
          {
              return NotFound();
          }
            return await _context.VehicleTypes.ToListAsync();
        }

        // GET: api/VehicleTypes/5
        /// <summary>
        /// Gets a specific Vehicle Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult VehicleType</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleType>> GetVehicleType(int id)
        {
          if (_context.VehicleTypes == null)
          {
              return NotFound();
          }
            var vehicleType = await _context.VehicleTypes.FindAsync(id);

            if (vehicleType == null)
            {
                return NotFound();
            }

            return vehicleType;
        }

        // PUT: api/VehicleTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Vehicle Type
        /// </summary>
        /// <param name="id"></param>
        /// <param name="vehicleType"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVehicleType(int id, VehicleType vehicleType)
        {
            if (id != vehicleType.Id)
            {
                return BadRequest();
            }

            _context.Entry(vehicleType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleTypeExists(id))
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

        // POST: api/VehicleTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Vehicle Type
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <returns>ActionResult VehicleType</returns>
        [HttpPost]
        public async Task<ActionResult<VehicleType>> PostVehicleType(VehicleType vehicleType)
        {
          if (_context.VehicleTypes == null)
          {
              return Problem("Entity set 'Entities.VehicleTypes'  is null.");
          }
            _context.VehicleTypes.Add(vehicleType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVehicleType", new { id = vehicleType.Id }, vehicleType);
        }

        // DELETE: api/VehicleTypes/5
        /// <summary>
        /// Deletes a specific Vehicle Type
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicleType(int id)
        {
            if (_context.VehicleTypes == null)
            {
                return NotFound();
            }
            var fartøyType = await _context.VehicleTypes.FindAsync(id);
            if (fartøyType == null)
            {
                return NotFound();
            }

            _context.VehicleTypes.Remove(fartøyType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VehicleTypeExists(int id)
        {
            return (_context.VehicleTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
