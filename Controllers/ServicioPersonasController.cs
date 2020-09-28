using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegundoParcial;
using SegundoParcial.Entities;

namespace SegundoParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioPersonasController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ServicioPersonasController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/ServicioPersonas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicioPersona>>> GetServicioPersona()
        {
            return await _context.ServicioPersona.ToListAsync();
        }

        // GET: api/ServicioPersonas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicioPersona>> GetServicioPersona(int id)
        {
            var servicioPersona = await _context.ServicioPersona.FindAsync(id);

            if (servicioPersona == null)
            {
                return NotFound();
            }

            return servicioPersona;
        }

        // PUT: api/ServicioPersonas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicioPersona(int id, ServicioPersona servicioPersona)
        {
            if (id != servicioPersona.id)
            {
                return BadRequest();
            }

            _context.Entry(servicioPersona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioPersonaExists(id))
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

        // POST: api/ServicioPersonas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ServicioPersona>> PostServicioPersona(ServicioPersona servicioPersona)
        {
            _context.ServicioPersona.Add(servicioPersona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicioPersona", new { id = servicioPersona.id }, servicioPersona);
        }

        // DELETE: api/ServicioPersonas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServicioPersona>> DeleteServicioPersona(int id)
        {
            var servicioPersona = await _context.ServicioPersona.FindAsync(id);
            if (servicioPersona == null)
            {
                return NotFound();
            }

            _context.ServicioPersona.Remove(servicioPersona);
            await _context.SaveChangesAsync();

            return servicioPersona;
        }

        private bool ServicioPersonaExists(int id)
        {
            return _context.ServicioPersona.Any(e => e.id == id);
        }
    }
}
