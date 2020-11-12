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
    public class ServicioPacientesController : ControllerBase
    {
        private readonly AppDBContext _context;

        public ServicioPacientesController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/ServicioPacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServicioPaciente>>> GetServicioPaciente()
        {
            return await _context.ServicioPaciente.ToListAsync();
        }

        // GET: api/ServicioPacientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServicioPaciente>> GetServicioPaciente(Guid id)
        {
            var servicioPaciente = await _context.ServicioPaciente.FindAsync(id);

            if (servicioPaciente == null)
            {
                return NotFound();
            }

            return servicioPaciente;
        }

        // PUT: api/ServicioPacientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicioPaciente(Guid id, ServicioPaciente servicioPaciente)
        {
            if (id != servicioPaciente.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicioPaciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioPacienteExists(id))
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

        // POST: api/ServicioPacientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ServicioPaciente>> PostServicioPaciente(ServicioPaciente servicioPaciente)
        {
            _context.ServicioPaciente.Add(servicioPaciente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServicioPaciente", new { id = servicioPaciente.Id }, servicioPaciente);
        }

        // DELETE: api/ServicioPacientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServicioPaciente>> DeleteServicioPaciente(Guid id)
        {
            var servicioPaciente = await _context.ServicioPaciente.FindAsync(id);
            if (servicioPaciente == null)
            {
                return NotFound();
            }

            _context.ServicioPaciente.Remove(servicioPaciente);
            await _context.SaveChangesAsync();

            return servicioPaciente;
        }

        private bool ServicioPacienteExists(Guid id)
        {
            return _context.ServicioPaciente.Any(e => e.Id == id);
        }
    }
}
