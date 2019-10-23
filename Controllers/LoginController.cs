using System;
using System.Linq;
using System.Threading.Tasks;
using AgilizaRH.Context;
using AgilizaRH.Helper;
using AgilizaRH.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgilizaRH.Controllers
{
    [Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AgilizaRHContext _context;
        Tools tool = new Tools();

        public LoginController(AgilizaRHContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Usuarios>> Login(Usuarios usuario)
        {
            var senha = tool.Criptografar(usuario.Senha);
            Usuarios user = _context.Usuarios.FirstOrDefault(a => a.Email == usuario.Email && a.Senha == senha);

            if (user != null)
            {
                user.Logado = true;
                _context.Entry(user).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                    tool.MontaLog(1, "O usuário " + user.Nome + "( " + user.Email + " )" + " logou no sistema", user.Id, "LOGIN");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return BadRequest(new { msg = ex.Message });
                    throw;
                }
            }
            else
            {
                tool.MontaLog(1, "Usuário ou senha incorreta, Login: " + usuario.Email, user.Id, "LOGIN");
                return NotFound(new { msg = "Login ou senha incorreta!" });
            }

            return user;
        }

        [HttpGet]
        public async Task<IActionResult> Logout(int usuarioId)
        {
            var user = await _context.Usuarios.FindAsync(usuarioId);

            if (user != null)
            {
                user.Logado = false;
                _context.Entry(user).State = EntityState.Modified;
                try
                {
                    await _context.SaveChangesAsync();
                    tool.MontaLog(1, "O usuário " + user.Nome + "( " + user.Email + " )" + " deslogou do sistema", user.Id, "LOGOUT");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return BadRequest(new { msg = ex.Message });
                    throw;
                }
            }
            else
            {
                return NotFound(new { msg = "Usuário não encontrado" });
            }

            return NoContent();
        }
    }
}