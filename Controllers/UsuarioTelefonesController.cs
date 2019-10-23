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
    public class UsuarioTelefonesController : ControllerBase
    {
        private readonly AgilizaRHContext _context;
        Tools tool = new Tools();

        public UsuarioTelefonesController(AgilizaRHContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioTelefones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioTelefones>>> GetUsuarioTelefones()
        {
            return await _context.UsuarioTelefones.ToListAsync();
        }

        // GET: api/UsuarioTelefones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioTelefones>> GetUsuarioTelefones(int id)
        {
            var usuarioTelefones = await _context.UsuarioTelefones.FindAsync(id);

            if (usuarioTelefones == null)
            {
                return NotFound();
            }

            return usuarioTelefones;
        }

        // PUT: api/UsuarioTelefones/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioTelefones(int id, UsuarioTelefones usuarioTelefones, int usuarioId)
        {
            if (id != usuarioTelefones.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioTelefones).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                tool.MontaLog(
                    5,
                    "Telefone: " + usuarioTelefones.Telefone
                    + " do Usuário Id: " + usuarioTelefones.Usuarios.Id
                    + " Usuário: " + usuarioTelefones.Usuarios.Nome
                    + " editado com sucesso.",
                    usuarioId,
                    "EDITAR"
                );
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioTelefonesExists(id))
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

        // POST: api/UsuarioTelefones
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UsuarioTelefones>> PostUsuarioTelefones(UsuarioTelefones usuarioTelefones, int usuarioId)
        {
            _context.UsuarioTelefones.Add(usuarioTelefones);
            await _context.SaveChangesAsync();

            tool.MontaLog(
                5,
                "Telefone: " + usuarioTelefones.Telefone
                + " do Usuário Id: " + usuarioTelefones.Usuarios.Id
                + " Usuário: " + usuarioTelefones.Usuarios.Nome
                + " adicionado com sucesso.",
                usuarioId,
                "ADICIONAR"
            );

            //return CreatedAtAction("GetUsuarioTelefones", new { id = usuarioTelefones.Id }, usuarioTelefones);
            return CreatedAtAction(nameof(GetUsuarioTelefones), new { id = usuarioTelefones.Id }, usuarioTelefones);
        }

        // DELETE: api/UsuarioTelefones/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioTelefones>> DeleteUsuarioTelefones(int id, int usuarioId)
        {
            var usuarioTelefones = await _context.UsuarioTelefones.FindAsync(id);
            if (usuarioTelefones == null)
            {
                return NotFound();
            }

            //_context.UsuarioTelefones.Remove(usuarioTelefones);

            usuarioTelefones.Ativo = !usuarioTelefones.Ativo;
            await _context.SaveChangesAsync();

            if (usuarioTelefones.Ativo)
            {
                tool.MontaLog(
                    5,
                    "Telefone: " + usuarioTelefones.Telefone
                    + " do Usuário Id: " + usuarioTelefones.Usuarios.Id
                    + " Usuário: " + usuarioTelefones.Usuarios.Nome
                    + " ativado com sucesso.",
                    usuarioId,
                    "ATIVAR/DESATIVAR"
                );
            }
            else
            {
                tool.MontaLog(
                    5,
                    "Telefone: " + usuarioTelefones.Telefone
                    + " do Usuário Id: " + usuarioTelefones.Usuarios.Id
                    + " Usuário: " + usuarioTelefones.Usuarios.Nome
                    + " desativado com sucesso.",
                    usuarioId,
                    "ATIVAR/DESATIVAR"
                );
            }

            return usuarioTelefones;
        }

        private bool UsuarioTelefonesExists(int id)
        {
            return _context.UsuarioTelefones.Any(e => e.Id == id);
        }
    }
}
