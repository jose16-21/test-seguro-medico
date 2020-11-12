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
    public class PagosController : ControllerBase
    {
        private readonly AppDBContext _context;

        public PagosController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/Pagos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pagos>>> GetPagos()
        {
            return await _context.Pagos.ToListAsync();
        }

        // GET: api/Pagos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pagos>> GetPagos(Guid id)
        {
            var pagos = await _context.Pagos.FindAsync(id);

            if (pagos == null)
            {
                return NotFound();
            }

            return pagos;
        }

        // PUT: api/Pagos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagos(Guid id, Pagos pagos)
        {
            if (id != pagos.Id)
            {
                return BadRequest();
            }

            _context.Entry(pagos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagosExists(id))
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

        // POST: api/Pagos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Pagos>> PostPagos(Pagos pagos)
        {
            _context.Pagos.Add(pagos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPagos", new { id = pagos.Id }, pagos);
        }

        // DELETE: api/Pagos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pagos>> DeletePagos(Guid id)
        {
            var pagos = await _context.Pagos.FindAsync(id);
            if (pagos == null)
            {
                return NotFound();
            }

            _context.Pagos.Remove(pagos);
            await _context.SaveChangesAsync();

            return pagos;
        }

        private bool PagosExists(Guid id)
        {
            return _context.Pagos.Any(e => e.Id == id);
        }
    }
}
