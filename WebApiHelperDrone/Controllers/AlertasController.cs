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
    public class AlertasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AlertasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alerta>>> GetAlertas()
        {
            return await _context.Alerta.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alerta>> GetAlerta(int id)
        {
            var alerta = await _context.Alerta.FindAsync(id);

            if (alerta == null)
            {
                return NotFound();
            }

            return alerta;
        }

        [HttpPost]
        public async Task<ActionResult<Alerta>> PostAlerta(Alerta alerta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Alerta.Add(alerta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAlerta), new { id = alerta.IdAlerta }, alerta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlerta(int id, Alerta alerta)
        {
            if (id != alerta.IdAlerta)
            {
                return BadRequest("ID do alerta não coincide com o objeto enviado");
            }

            _context.Entry(alerta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlertaExists(id))
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
        public async Task<IActionResult> DeleteAlerta(int id)
        {
            var alerta = await _context.Alerta.FindAsync(id);
            if (alerta == null)
            {
                return NotFound();
            }

            _context.Alerta.Remove(alerta);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlertaExists(int id)
        {
            return _context.Alerta.Any(e => e.IdAlerta == id);
        }
    }
}
