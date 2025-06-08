using WebApiHelperDrone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiHelperDrone.Context;

namespace WebApiHelperDrone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DronesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DronesController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drone>>> GetDrone()
        {
            return await _context.Drones.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Drone>> GetDrone(int id)
        {
            var drone = await _context.Drones.FindAsync(id);

            if (drone == null)
            {
                return NotFound();
            }

            return drone;
        }

        [HttpPost]
        public async Task<ActionResult<Drone>> PostDrone(Drone drone)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Drones.Add(drone);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDrone), new { id = drone.IdDrone }, drone);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDrone(int id, Drone drone)
        {
            if (id != drone.IdDrone)
            {
                return BadRequest("ID do drone não coincide com o objeto enviado");
            }

            _context.Entry(drone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DroneExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDrone(int id)
        {
            var drone = await _context.Drones.FindAsync(id);
            if (drone == null)
            {
                return NotFound();
            }

            _context.Drones.Remove(drone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DroneExists(int id)
        {
            return _context.Drones.Any(e => e.IdDrone == id);
        }
    }
}
