using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgilizaRH.Context;
using AgilizaRH.Models;
using AgilizaRH.Helper;

namespace AgilizaRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoPromocoesController : ControllerBase
    {
        private readonly AgilizaRHContext _context;
        Tools tool = new Tools();

        public HistoricoPromocoesController(AgilizaRHContext context)
        {
            _context = context;
        }

        // GET: api/HistoricoPromocoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoPromocoes>>> GetHistoricoPromocoes()
        {
            return await _context.HistoricoPromocoes.ToListAsync();
        }

        // GET: api/HistoricoPromocoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoPromocoes>> GetHistoricoPromocoes(int id)
        {
            var historicoPromocoes = await _context.HistoricoPromocoes.FindAsync(id);

            if (historicoPromocoes == null)
            {
                return NotFound();
            }

            return historicoPromocoes;
        }

        //// PUT: api/HistoricoPromocoes/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutHistoricoPromocoes(int id, HistoricoPromocoes historicoPromocoes, int usuarioId)
        //{
        //    if (id != historicoPromocoes.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(historicoPromocoes).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!HistoricoPromocoesExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/HistoricoPromocoes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<HistoricoPromocoes>> PostHistoricoPromocoes(HistoricoPromocoes historicoPromocoes, int usuarioId)
        {
            _context.HistoricoPromocoes.Add(historicoPromocoes);
            await _context.SaveChangesAsync();

            tool.MontaLog(5, "Histórico de Promoções Id: " + historicoPromocoes.Id + " do Usuário: " + historicoPromocoes.Usuarios.Nome + " adicionado com sucesso.", usuarioId, "ADICIONAR");

            //return CreatedAtAction("GetHistoricoPromocoes", new { id = historicoPromocoes.Id }, historicoPromocoes);
            return CreatedAtAction(nameof(GetHistoricoPromocoes), new { id = historicoPromocoes.Id }, historicoPromocoes);
        }

        //// DELETE: api/HistoricoPromocoes/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<HistoricoPromocoes>> DeleteHistoricoPromocoes(int id, int usuarioId)
        //{
        //    var historicoPromocoes = await _context.HistoricoPromocoes.FindAsync(id);
        //    if (historicoPromocoes == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.HistoricoPromocoes.Remove(historicoPromocoes);
        //    await _context.SaveChangesAsync();

        //    return historicoPromocoes;
        //}

        private bool HistoricoPromocoesExists(int id)
        {
            return _context.HistoricoPromocoes.Any(e => e.Id == id);
        }
    }
}
