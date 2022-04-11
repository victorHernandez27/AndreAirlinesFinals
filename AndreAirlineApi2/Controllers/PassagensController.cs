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
    public class PassagensController : ControllerBase
    {
        private readonly AndreAirlineApi2Context _context;

        public PassagensController(AndreAirlineApi2Context context)
        {
            _context = context;
        }

        // GET: api/Passagems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passagem>>> GetPassagem()
        {
            return await _context.Passagem.ToListAsync();
        }

        // GET: api/Passagems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passagem>> GetPassagem(int id)
        {
            var passagem = await _context.Passagem.FindAsync(id);

            if (passagem == null)
            {
                return NotFound();
            }

            return passagem;
        }

        // PUT: api/Passagems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassagem(int id, Passagem passagem)
        {
            if (id != passagem.Id)
            {
                return BadRequest();
            }

            _context.Entry(passagem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassagemExists(id))
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

        // POST: api/Passagems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passagem>> PostPassagem(Passagem passagem)
        {
            var voo = _context.Voo
                .Include(p => p.Origem)
                .Include(p => p.Destino)
                .FirstOrDefault(p => p.Id == passagem.Voo.Id);
            if (voo == null)
                return BadRequest("Voo não Localizado.");

            var passageiro = _context.Passageiro.Find(passagem.Passageiro.Cpf);
            if (passageiro == null)
                return BadRequest("Passageiro não Localizada.");

            var classe = _context.Classe.Find(passagem.Classe.Id);
            if (classe == null)
                return BadRequest("Classe não Localizada.");

            var precoBase = _context.PrecoBase
                .Include(p => p.Origem)
                .Include(p => p.Destino)
                .Include(p => p.Classe)
                .Where(p => p.Origem.Sigla == voo.Origem.Sigla &&
                    p.Destino.Sigla == voo.Destino.Sigla &&
                    p.Classe.Id == classe.Id).OrderByDescending(p => p.DataInclusao)
                .FirstOrDefault();

            if (precoBase == null)
                return BadRequest("Preço Base não Localizado.");

            var desconto = (precoBase.Valor * (decimal)precoBase.PromocaoPorcentagem) / 100;

            passagem.Voo = voo;
            passagem.Passageiro = passageiro;
            passagem.Valor = precoBase.Valor - desconto;
            passagem.Classe = classe;
            passagem.DataCadastro = DateTime.Now;

            _context.Passagem.Add(passagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPassagem", new { id = passagem.Id }, passagem);
        }

        // DELETE: api/Passagems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassagem(int id)
        {
            var passagem = await _context.Passagem.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }

            _context.Passagem.Remove(passagem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PassagemExists(int id)
        {
            return _context.Passagem.Any(e => e.Id == id);
        }
    }
}
