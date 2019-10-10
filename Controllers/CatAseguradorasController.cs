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
    public class CatAseguradorasController : ControllerBase
    {
        private readonly dbexContext _context;

        public CatAseguradorasController(dbexContext context)
        {
            _context = context;
        }

        // GET: api/CatAseguradoras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CatAseguradoras>>> GetCatAseguradoras()
        {
            return await _context.CatAseguradoras.ToListAsync();
        }

        // GET: api/CatAseguradoras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CatAseguradoras>> GetCatAseguradoras(int id)
        {
            var catAseguradoras = await _context.CatAseguradoras.FindAsync(id);

            if (catAseguradoras == null)
            {
                return NotFound();
            }

            return catAseguradoras;
        }

        // PUT: api/CatAseguradoras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatAseguradoras(int id, CatAseguradoras catAseguradoras)
        {
            if (id != catAseguradoras.IdAseguradora)
            {
                return BadRequest();
            }

            _context.Entry(catAseguradoras).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatAseguradorasExists(id))
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

        // POST: api/CatAseguradoras
        [HttpPost]
        public async Task<ActionResult<CatAseguradoras>> PostCatAseguradoras(CatAseguradoras catAseguradoras)
        {
            _context.CatAseguradoras.Add(catAseguradoras);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatAseguradoras", new { id = catAseguradoras.IdAseguradora }, catAseguradoras);
        }

        // DELETE: api/CatAseguradoras/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CatAseguradoras>> DeleteCatAseguradoras(int id)
        {
            var catAseguradoras = await _context.CatAseguradoras.FindAsync(id);
            if (catAseguradoras == null)
            {
                return NotFound();
            }

            _context.CatAseguradoras.Remove(catAseguradoras);
            await _context.SaveChangesAsync();

            return catAseguradoras;
        }

        private bool CatAseguradorasExists(int id)
        {
            return _context.CatAseguradoras.Any(e => e.IdAseguradora == id);
        }
    }
}
