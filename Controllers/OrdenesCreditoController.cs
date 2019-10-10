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
    public class OrdenesCreditoController : ControllerBase
    {
        private readonly dbexContext _context;

        public OrdenesCreditoController(dbexContext context)
        {
            _context = context;
        }

        // GET: api/OrdenesCredito
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenesCredito>>> GetOrdenesCredito()
        {
            return await _context.OrdenesCredito.ToListAsync();
        }

        // GET: api/OrdenesCredito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenesCredito>> GetOrdenesCredito(int id)
        {
            var ordenesCredito = await _context.OrdenesCredito.FindAsync(id);

            if (ordenesCredito == null)
            {
                return NotFound();
            }

            return ordenesCredito;
        }

        // PUT: api/OrdenesCredito/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenesCredito(int id, OrdenesCredito ordenesCredito)
        {
            if (id != ordenesCredito.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordenesCredito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenesCreditoExists(id))
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

        // POST: api/OrdenesCredito
        [HttpPost]
        public async Task<ActionResult<OrdenesCredito>> PostOrdenesCredito(OrdenesCredito ordenesCredito)
        {
            _context.OrdenesCredito.Add(ordenesCredito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenesCredito", new { id = ordenesCredito.Id }, ordenesCredito);
        }

        // DELETE: api/OrdenesCredito/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdenesCredito>> DeleteOrdenesCredito(int id)
        {
            var ordenesCredito = await _context.OrdenesCredito.FindAsync(id);
            if (ordenesCredito == null)
            {
                return NotFound();
            }

            _context.OrdenesCredito.Remove(ordenesCredito);
            await _context.SaveChangesAsync();

            return ordenesCredito;
        }

        private bool OrdenesCreditoExists(int id)
        {
            return _context.OrdenesCredito.Any(e => e.Id == id);
        }
    }
}
