﻿using System;
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
    public class PassageiroesController : ControllerBase
    {
        private readonly AndreAirlineApi2Context _context;

        public PassageiroesController(AndreAirlineApi2Context context)
        {
            _context = context;
        }

        // GET: api/Passageiroes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passageiro>>> GetPassageiro()
        {
            return await _context.Passageiro.ToListAsync();
        }

        // GET: api/Passageiroes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passageiro>> GetPassageiro(string id)
        {
            var passageiro = await _context.Passageiro.FindAsync(id);

            if (passageiro == null)
            {
                return NotFound();
            }

            return passageiro;
        }

        // PUT: api/Passageiroes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassageiro(string id, Passageiro passageiro)
        {
            if (id != passageiro.Cpf)
            {
                return BadRequest();
            }

            _context.Entry(passageiro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassageiroExists(id))
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

        // POST: api/Passageiroes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passageiro>> PostPassageiro(Passageiro passageiro)
        {
            _context.Passageiro.Add(passageiro);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PassageiroExists(passageiro.Cpf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPassageiro", new { id = passageiro.Cpf }, passageiro);
        }

        // DELETE: api/Passageiroes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassageiro(string id)
        {
            var passageiro = await _context.Passageiro.FindAsync(id);
            if (passageiro == null)
            {
                return NotFound();
            }

            _context.Passageiro.Remove(passageiro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassageiroExists(string id)
        {
            return _context.Passageiro.Any(e => e.Cpf == id);
        }
    }
}
