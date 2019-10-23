using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgilizaRH.Models;
using AgilizaRH.Helper;

namespace AgilizaRH.Context
{
    [Route("api/[controller]")]
    [ApiController]
    public class GratificacoesController : ControllerBase
    {
        private readonly AgilizaRHContext _context;
        Tools tool = new Tools();

        public GratificacoesController(AgilizaRHContext context)
        {
            _context = context;
        }

        // GET: api/Gratificacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gratificacoes>>> GetGratificacoes()
        {
            return await _context.Gratificacoes.ToListAsync();
        }

        // GET: api/Gratificacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Gratificacoes>> GetGratificacoes(int id)
        {
            var gratificacoes = await _context.Gratificacoes.FindAsync(id);

            if (gratificacoes == null)
            {
                return NotFound();
            }

            return gratificacoes;
        }

        // PUT: api/Gratificacoes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGratificacoes(int id, Gratificacoes gratificacoes, int usuarioId)
        {
            if (id != gratificacoes.Id)
            {
                return BadRequest();
            }

            _context.Entry(gratificacoes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                tool.MontaLog(3, "Gratificação Id: " + gratificacoes.Id + " Tipo: " + gratificacoes.Tipo + " editado com sucesso.", usuarioId, "EDITAR");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GratificacoesExists(id))
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

        // POST: api/Gratificacoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Gratificacoes>> PostGratificacoes(Gratificacoes gratificacoes, int usuarioId)
        {
            _context.Gratificacoes.Add(gratificacoes);
            await _context.SaveChangesAsync();

            tool.MontaLog(3, "Gratificação Id: " + gratificacoes.Id + " Tipo: " + gratificacoes.Tipo + " adicionado com sucesso.", usuarioId, "ADICIONAR");

            //return CreatedAtAction("GetGratificacoes", new { id = gratificacoes.Id }, gratificacoes);
            return CreatedAtAction(nameof(GetGratificacoes), new { id = gratificacoes.Id }, gratificacoes);
        }

        // DELETE: api/Gratificacoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Gratificacoes>> DeleteGratificacoes(int id, int usuarioId)
        {
            var gratificacoes = await _context.Gratificacoes.FindAsync(id);
            if (gratificacoes == null)
            {
                return NotFound();
            }

            //_context.Gratificacoes.Remove(gratificacoes);
            gratificacoes.Ativo = !gratificacoes.Ativo;
            await _context.SaveChangesAsync();

            if (gratificacoes.Ativo)
            {
                tool.MontaLog(3, "Gratificação Id: " + gratificacoes.Id + " Tipo: " + gratificacoes.Tipo + " ativado com sucesso.", usuarioId, "ATIVAR/DESATIVAR");
            }
            else
            {
                tool.MontaLog(3, "Gratificação Id: " + gratificacoes.Id + " Tipo: " + gratificacoes.Tipo + " desativado com sucesso.", usuarioId, "ATIVAR/DESATIVAR");
            }

            return gratificacoes;
        }

        private bool GratificacoesExists(int id)
        {
            return _context.Gratificacoes.Any(e => e.Id == id);
        }
    }
}
