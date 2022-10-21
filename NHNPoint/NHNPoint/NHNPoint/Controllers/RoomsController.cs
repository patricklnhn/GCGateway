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
    public class RoomsController : ControllerBase
    {
        private readonly Entities _context;
        /// <summary>
        /// Contains Rooms
        /// </summary>
        /// <param name="context"></param>

        public RoomsController(Entities context)
        {
            _context = context;
        }

        // GET: api/Rooms
        /// <summary>
        /// Gets all Rooms
        /// </summary>
        /// <returns>ActionResult IEnumerable Room</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
          if (_context.Rooms == null)
          {
              return NotFound();
          }
            return await _context.Rooms.ToListAsync();
        }

        // GET: api/Rooms/5
        /// <summary>
        /// Gets a specific Room
        /// </summary>
        /// <param name="id"></param>
        /// <returns>ActionResult Room</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
          if (_context.Rooms == null)
          {
              return NotFound();
          }
            var rom = await _context.Rooms.FindAsync(id);

            if (rom == null)
            {
                return NotFound();
            }

            return rom;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Updates a specific Room
        /// </summary>
        /// <param name="id"></param>
        /// <param name="rom"></param>
        /// <returns>IActionResult</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room rom)
        {
            if (id != rom.Id)
            {
                return BadRequest();
            }

            _context.Entry(rom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(id))
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

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// <summary>
        /// Creates new Room
        /// </summary>
        /// <param name="rom"></param>
        /// <returns>ActionResult Room</returns>
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room rom)
        {
          if (_context.Rooms == null)
          {
              return Problem("Entity set 'Entities.Rooms'  is null.");
          }
            _context.Rooms.Add(rom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoom", new { id = rom.Id }, rom);
        }

        // DELETE: api/Rooms/5
        /// <summary>
        /// Deletes a specific Room
        /// </summary>
        /// <param name="id"></param>
        /// <returns>IActionResult</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var rom = await _context.Rooms.FindAsync(id);
            if (rom == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(rom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomExists(int id)
        {
            return (_context.Rooms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
