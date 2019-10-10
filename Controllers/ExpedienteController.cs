using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apicime.Models;

namespace apicime.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedienteController : ControllerBase
    {
        private readonly dbexContext _context;

        public ExpedienteController(dbexContext context)
        {
            _context = context;
        }

        // GET: api/Expediente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expediente>>> GetExpediente()
        {
            return await _context.Expediente.ToListAsync();
        }

        // GET: api/Expediente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expediente>> GetExpediente(int id)
        {
            var expediente = await _context.Expediente.FindAsync(id);

            if (expediente == null)
            {
                return NotFound();
            }

            return expediente;
        }

        // PUT: api/Expediente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpediente(int id, Expediente expediente)
        {
            if (id != expediente.Id)
            {
                return BadRequest();
            }

            _context.Entry(expediente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpedienteExists(id))
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

        // POST: api/Expediente
        [HttpPost]
        public async Task<ActionResult<Expediente>> PostExpediente(Expediente expediente)
        {
            _context.Expediente.Add(expediente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpediente", new { id = expediente.Id }, expediente);
        }

        // DELETE: api/Expediente/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Expediente>> DeleteExpediente(int id)
        {
            var expediente = await _context.Expediente.FindAsync(id);
            if (expediente == null)
            {
                return NotFound();
            }

            _context.Expediente.Remove(expediente);
            await _context.SaveChangesAsync();

            return expediente;
        }

        private bool ExpedienteExists(int id)
        {
            return _context.Expediente.Any(e => e.Id == id);
        }
    }
}
