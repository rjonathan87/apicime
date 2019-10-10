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
    public class OrdenesContadoController : ControllerBase
    {
        private readonly dbexContext _context;

        public OrdenesContadoController(dbexContext context)
        {
            _context = context;
        }

        // GET: api/OrdenesContado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenesContado>>> GetOrdenesContado()
        {
            return await _context.OrdenesContado.ToListAsync();
        }

        // GET: api/OrdenesContado/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenesContado>> GetOrdenesContado(int id)
        {
            var ordenesContado = await _context.OrdenesContado.FindAsync(id);

            if (ordenesContado == null)
            {
                return NotFound();
            }

            return ordenesContado;
        }

        // PUT: api/OrdenesContado/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrdenesContado(int id, OrdenesContado ordenesContado)
        {
            if (id != ordenesContado.Id)
            {
                return BadRequest();
            }

            _context.Entry(ordenesContado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdenesContadoExists(id))
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

        // POST: api/OrdenesContado
        [HttpPost]
        public async Task<ActionResult<OrdenesContado>> PostOrdenesContado(OrdenesContado ordenesContado)
        {
            _context.OrdenesContado.Add(ordenesContado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrdenesContado", new { id = ordenesContado.Id }, ordenesContado);
        }

        // DELETE: api/OrdenesContado/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdenesContado>> DeleteOrdenesContado(int id)
        {
            var ordenesContado = await _context.OrdenesContado.FindAsync(id);
            if (ordenesContado == null)
            {
                return NotFound();
            }

            _context.OrdenesContado.Remove(ordenesContado);
            await _context.SaveChangesAsync();

            return ordenesContado;
        }

        private bool OrdenesContadoExists(int id)
        {
            return _context.OrdenesContado.Any(e => e.Id == id);
        }
    }
}
