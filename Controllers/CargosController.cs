using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgilizaRH.Context;
using AgilizaRH.Models;

namespace AgilizaRH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly AgilizaRHContext _context;

        public CargosController(AgilizaRHContext context)
        {
            _context = context;
        }

        #region CRUD
        // GET: api/Cargos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cargos>>> GetCargos()
        {
            return await _context.Cargos.ToListAsync();
        }

        // GET: api/Cargos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cargos>> GetCargos(int id)
        {
            var cargos = await _context.Cargos.FindAsync(id);

            if (cargos == null)
            {
                return NotFound();
            }

            return cargos;
        }

        // PUT: api/Cargos/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCargos(int id, Cargos cargos)
        {
            if (id != cargos.Id)
            {
                return BadRequest();
            }

            _context.Entry(cargos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CargosExists(id))
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

        // POST: api/Cargos
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cargos>> PostCargos(Cargos cargos)
        {
            _context.Cargos.Add(cargos);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCargos", new { id = cargos.Id }, cargos);
            return CreatedAtAction(nameof(GetCargos), new { id = cargos.Id }, cargos);
        }

        // DELETE: api/Cargos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cargos>> DeleteCargos(int id)
        {
            var cargos = await _context.Cargos.FindAsync(id);
            if (cargos == null)
            {
                return NotFound();
            }

            //_context.Cargos.Remove(cargos);

            cargos.Ativo = !cargos.Ativo;

            await _context.SaveChangesAsync();

            return cargos;
        }

        private bool CargosExists(int id)
        {
            return _context.Cargos.Any(e => e.Id == id);
        }
        #endregion
    }
}
