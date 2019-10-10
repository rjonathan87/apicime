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
    public class CodigoPostalController : ControllerBase
    {
        private readonly dbexContext _context;

        public CodigoPostalController(dbexContext context)
        {
            _context = context;
        }

        // GET: api/CodigoPostal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CodigoPostal>>> GetCodigoPostal()
        {
            return await _context.CodigoPostal.ToListAsync();
        }

        // GET: api/CodigoPostal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CodigoPostal>> GetCodigoPostal(int id)
        {
            var codigoPostal = await _context.CodigoPostal.FindAsync(id);

            if (codigoPostal == null)
            {
                return NotFound();
            }

            return codigoPostal;
        }

        // PUT: api/CodigoPostal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCodigoPostal(int id, CodigoPostal codigoPostal)
        {
            if (id != codigoPostal.Id)
            {
                return BadRequest();
            }

            _context.Entry(codigoPostal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CodigoPostalExists(id))
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

        // POST: api/CodigoPostal
        [HttpPost]
        public async Task<ActionResult<CodigoPostal>> PostCodigoPostal(CodigoPostal codigoPostal)
        {
            _context.CodigoPostal.Add(codigoPostal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCodigoPostal", new { id = codigoPostal.Id }, codigoPostal);
        }

        // DELETE: api/CodigoPostal/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CodigoPostal>> DeleteCodigoPostal(int id)
        {
            var codigoPostal = await _context.CodigoPostal.FindAsync(id);
            if (codigoPostal == null)
            {
                return NotFound();
            }

            _context.CodigoPostal.Remove(codigoPostal);
            await _context.SaveChangesAsync();

            return codigoPostal;
        }

        private bool CodigoPostalExists(int id)
        {
            return _context.CodigoPostal.Any(e => e.Id == id);
        }
    }
}
