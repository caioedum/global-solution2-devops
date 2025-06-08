using WebApiHelperDrone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiHelperDrone.Context;

namespace WebApiHelperDrone.Controllers
{
    public class AreasRiscoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AreasRiscoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaRisco>>> GetAreasRisco()
        {
            return await _context.AreasRisco.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AreaRisco>> GetAreaRisco(int id)
        {
            var areaRisco = await _context.AreasRisco.FindAsync(id);

            if (areaRisco == null)
            {
                return NotFound();
            }

            return areaRisco;
        }

        [HttpPost]
        public async Task<ActionResult<AreaRisco>> PostAreaRisco(AreaRisco areaRisco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.AreasRisco.Add(areaRisco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAreaRisco), new { id = areaRisco.IdArea }, areaRisco);
        }

        // PUT: api/AreasRisco/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAreaRisco(int id, AreaRisco areaRisco)
        {
            if (id != areaRisco.IdArea)
            {
                return BadRequest("ID da área de risco não coincide com o objeto enviado");
            }

            _context.Entry(areaRisco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AreaRiscoExists(id))
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

        // DELETE: api/AreasRisco/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAreaRisco(int id)
        {
            var areaRisco = await _context.AreasRisco.FindAsync(id);
            if (areaRisco == null)
            {
                return NotFound();
            }

            _context.AreasRisco.Remove(areaRisco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AreaRiscoExists(int id)
        {
            return _context.AreasRisco.Any(e => e.IdArea == id);
        }
    }
}
