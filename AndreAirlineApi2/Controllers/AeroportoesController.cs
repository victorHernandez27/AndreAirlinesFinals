using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreAirlineApi2.Data;
using AndreAirlineApi2.Model;

namespace AndreAirlineApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AeroportoesController : ControllerBase
    {
        private readonly AndreAirlineApi2Context _context;

        public AeroportoesController(AndreAirlineApi2Context context)
        {
            _context = context;
        }

        // GET: api/Aeroportoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeroporto>>> GetAeroporto()
        {
            return await _context.Aeroporto.ToListAsync();
        }

        // GET: api/Aeroportoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aeroporto>> GetAeroporto(string id)
        {
            var aeroporto = await _context.Aeroporto.FindAsync(id);

            if (aeroporto == null)
            {
                return NotFound();
            }

            return aeroporto;
        }

        // PUT: api/Aeroportoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeroporto(string id, Aeroporto aeroporto)
        {
            if (id != aeroporto.Sigla)
            {
                return BadRequest();
            }

            _context.Entry(aeroporto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeroportoExists(id))
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

        // POST: api/Aeroportoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aeroporto>> PostAeroporto(Aeroporto aeroporto)
        {
            _context.Aeroporto.Add(aeroporto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AeroportoExists(aeroporto.Sigla))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAeroporto", new { id = aeroporto.Sigla }, aeroporto);
        }

        // DELETE: api/Aeroportoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeroporto(string id)
        {
            var aeroporto = await _context.Aeroporto.FindAsync(id);
            if (aeroporto == null)
            {
                return NotFound();
            }

            _context.Aeroporto.Remove(aeroporto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeroportoExists(string id)
        {
            return _context.Aeroporto.Any(e => e.Sigla == id);
        }
    }
}
