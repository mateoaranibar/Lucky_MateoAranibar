using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegundoParcial.Data;
using SegundoParcial.Models;

namespace SegundoParcial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuerteController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SuerteController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Suerte
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Suerte>>> GetLucky()
        {
            return await _context.Lucky.ToListAsync();
        }

        // GET: api/Suerte/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Suerte>> GetSuerte(int id)
        {
            var suerte = await _context.Lucky.FindAsync(id);

            if (suerte == null)
            {
                return NotFound();
            }

            return suerte;
        }

        // PUT: api/Suerte/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSuerte(int id, Suerte suerte)
        {
            if (id != suerte.SuerteId)
            {
                return BadRequest();
            }

            _context.Entry(suerte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SuerteExists(id))
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

        // POST: api/Suerte
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Suerte>> PostSuerte(Suerte suerte)
        {
            _context.Lucky.Add(suerte);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSuerte", new { id = suerte.SuerteId }, suerte);
        }

        // DELETE: api/Suerte/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuerte(int id)
        {
            var suerte = await _context.Lucky.FindAsync(id);
            if (suerte == null)
            {
                return NotFound();
            }

            _context.Lucky.Remove(suerte);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SuerteExists(int id)
        {
            return _context.Lucky.Any(e => e.SuerteId == id);
        }
    }
}
