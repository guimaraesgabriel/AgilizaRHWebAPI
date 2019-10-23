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
    public class HistoricoFeriasController : ControllerBase
    {
        private readonly AgilizaRHContext _context;
        Tools tool = new Tools();

        public HistoricoFeriasController(AgilizaRHContext context)
        {
            _context = context;
        }

        // GET: api/HistoricoFerias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistoricoFerias>>> GetHistoricoFerias()
        {
            return await _context.HistoricoFerias.ToListAsync();
        }

        // GET: api/HistoricoFerias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistoricoFerias>> GetHistoricoFerias(int id)
        {
            var historicoFerias = await _context.HistoricoFerias.FindAsync(id);

            if (historicoFerias == null)
            {
                return NotFound();
            }

            return historicoFerias;
        }

        //// PUT: api/HistoricoFerias/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutHistoricoFerias(int id, HistoricoFerias historicoFerias, int usuarioId)
        //{
        //    if (id != historicoFerias.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(historicoFerias).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!HistoricoFeriasExists(id))
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

        // POST: api/HistoricoFerias
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<HistoricoFerias>> PostHistoricoFerias(HistoricoFerias historicoFerias, int usuarioId)
        {
            _context.HistoricoFerias.Add(historicoFerias);
            await _context.SaveChangesAsync();

            tool.MontaLog(5, "Histórico de Férias Id: " + historicoFerias.Id + " do Usuário: " + historicoFerias.Usuarios.Nome + " adicionado com sucesso.", usuarioId, "ADICIONAR");

            //return CreatedAtAction("GetHistoricoFerias", new { id = historicoFerias.Id }, historicoFerias);
            return CreatedAtAction(nameof(GetHistoricoFerias), new { id = historicoFerias.Id }, historicoFerias);
        }

        //// DELETE: api/HistoricoFerias/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<HistoricoFerias>> DeleteHistoricoFerias(int id, int usuarioId)
        //{
        //    var historicoFerias = await _context.HistoricoFerias.FindAsync(id);
        //    if (historicoFerias == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.HistoricoFerias.Remove(historicoFerias);
        //    await _context.SaveChangesAsync();

        //    return historicoFerias;
        //}

        private bool HistoricoFeriasExists(int id)
        {
            return _context.HistoricoFerias.Any(e => e.Id == id);
        }
    }
}
