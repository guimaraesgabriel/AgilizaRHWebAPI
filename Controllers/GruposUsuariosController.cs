using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgilizaRH.Context;
using AgilizaRH.Helper;

namespace AgilizaRH.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposUsuariosController : ControllerBase
    {
        private readonly AgilizaRHContext _context;
        Tools tool = new Tools();

        public GruposUsuariosController(AgilizaRHContext context)
        {
            _context = context;
        }

        // GET: api/GruposUsuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GruposUsuarios>>> GetGruposUsuarios()
        {
            return await _context.GruposUsuarios.ToListAsync();
        }

        // GET: api/GruposUsuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GruposUsuarios>> GetGruposUsuarios(int id)
        {
            var gruposUsuarios = await _context.GruposUsuarios.FindAsync(id);

            if (gruposUsuarios == null)
            {
                return NotFound();
            }

            return gruposUsuarios;
        }

        // PUT: api/GruposUsuarios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGruposUsuarios(int id, GruposUsuarios gruposUsuarios, int usuarioId)
        {
            if (id != gruposUsuarios.Id)
            {
                return BadRequest();
            }

            _context.Entry(gruposUsuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                tool.MontaLog(4, "Grupo de Usuários Id: " + gruposUsuarios.Id + " Grupo: " + gruposUsuarios.Grupo + " editado com sucesso.", usuarioId, "EDITAR");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GruposUsuariosExists(id))
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

        // POST: api/GruposUsuarios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<GruposUsuarios>> PostGruposUsuarios(GruposUsuarios gruposUsuarios, int usuarioId)
        {
            _context.GruposUsuarios.Add(gruposUsuarios);
            await _context.SaveChangesAsync();

            tool.MontaLog(4, "Grupo de Usuários Id: " + gruposUsuarios.Id + " Grupo: " + gruposUsuarios.Grupo + " adicionado com sucesso.", usuarioId, "ADICIONAR");

            //return CreatedAtAction("GetGruposUsuarios", new { id = gruposUsuarios.Id }, gruposUsuarios);
            return CreatedAtAction(nameof(GetGruposUsuarios), new { id = gruposUsuarios.Id }, gruposUsuarios);
        }

        // DELETE: api/GruposUsuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GruposUsuarios>> DeleteGruposUsuarios(int id, int usuarioId)
        {
            var gruposUsuarios = await _context.GruposUsuarios.FindAsync(id);
            if (gruposUsuarios == null)
            {
                return NotFound();
            }

            //_context.GruposUsuarios.Remove(gruposUsuarios);
            gruposUsuarios.Ativo = !gruposUsuarios.Ativo;
            await _context.SaveChangesAsync();

            if (gruposUsuarios.Ativo)
            {
                tool.MontaLog(4, "Grupo de Usuário Id: " + gruposUsuarios.Id + " Grupo: " + gruposUsuarios.Grupo + " ativado com sucesso.", usuarioId, "ATIVAR/DESATIVAR");
            }
            else
            {
                tool.MontaLog(4, "Grupo de Usuário Id: " + gruposUsuarios.Id + " Grupo: " + gruposUsuarios.Grupo + " desativado com sucesso.", usuarioId, "ATIVAR/DESATIVAR");
            }

            return gruposUsuarios;
        }

        private bool GruposUsuariosExists(int id)
        {
            return _context.GruposUsuarios.Any(e => e.Id == id);
        }
    }
}
