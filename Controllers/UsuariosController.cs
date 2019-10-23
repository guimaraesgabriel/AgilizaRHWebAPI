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
    public class UsuariosController : ControllerBase
    {
        private readonly AgilizaRHContext _context;
        Tools tool = new Tools();

        public UsuariosController(AgilizaRHContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarios(int id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(int id, Usuarios usuarios, int usuarioId)
        {
            if (id != usuarios.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

                tool.MontaLog(5, "Usuário Id: " + usuarios.Id + " Nome: " + usuarios.Nome + " editado com sucesso.", usuarioId, "EDITAR");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Usuarios>> PostUsuarios(Usuarios usuarios, int usuarioId)
        {
            _context.Usuarios.Add(usuarios);
            await _context.SaveChangesAsync();

            tool.MontaLog(5, "Usuário Id: " + usuarios.Id + " Nome: " + usuarios.Nome + " adicionado com sucesso.", usuarioId, "ADICIONAR");

            //return CreatedAtAction("GetUsuarios", new { id = usuarios.Id }, usuarios);
            return CreatedAtAction(nameof(GetUsuarios), new { id = usuarios.Id }, usuarios);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuarios>> DeleteUsuarios(int id, int usuarioId)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            //_context.Usuarios.Remove(usuarios);

            usuarios.Ativo = !usuarios.Ativo;
            await _context.SaveChangesAsync();

            if (usuarios.Ativo)
            {
                tool.MontaLog(5, "Usuário Id: " + usuarios.Id + " Nome: " + usuarios.Nome + " ativado com sucesso.", usuarioId, "ATIVAR/DESATIVAR");
            }
            else
            {
                tool.MontaLog(5, "Usuário Id: " + usuarios.Id + " Nome: " + usuarios.Nome + " desativado com sucesso.", usuarioId, "ATIVAR/DESATIVAR");
            }

            return usuarios;
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
