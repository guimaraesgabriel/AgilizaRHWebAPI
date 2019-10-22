using System;
using System.Linq;
using AgilizaRH.Context;
using AgilizaRH.Helper;
using Microsoft.AspNetCore.Mvc;

namespace AgilizaRH.Controllers
{
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

        //[HttpPost]
        //[Route("api/Login/Login/")]
        //public JsonResult Login(dynamic obj)
        //{
        //    string email = obj.email.Value;
        //    string senha = obj.senha.Value;

        //    try
        //    {
        //        var senhaCrypt = tool.Criptografar(senha);

        //        var usuario = _context.Usuarios.FirstOrDefault(a => a.Email == email && a.Senha == senhaCrypt );

        //        if (usuario == null)
        //        {
        //            tool.MontaLog(1, "ERRO DE AUTENTICAÇÃO - Usuário não encontrado", null, "LOGIN");

        //            return Json(new { success = false, msg = "Usuário não encontrado" });
        //        }
        //        else
        //        {
        //            if (usuario.Ativo == false)
        //            {
        //                tool.MontaLog(1, "ERRO DE AUTENTICAÇÃO - Usuário inativo", usuario.Id, "LOGIN");

        //                return Json(new { success = false, msg = "Usuário inativo" });
        //            }
        //            else
        //            {
        //                tool.MontaLog(1, "LOGIN REALIZADO COM SUCESSO", usuario.Id, "LOGIN");

        //                return Json(new
        //                {
        //                    success = true,
        //                    usuarioId = usuario.Id,
        //                    nome = usuario.Nome,
        //                    data = DateTime.Now.ToString("dd/MM/yyyy")
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        tool.MontaLog(1, "ERRO AO LOGAR", null, "ERRO");

        //        return Json(new { success = false, msg = ex });
        //    }
        //}

        //[HttpPost]
        //[Route("api/Login/Logout/")]
        //public void Logout(dynamic obj)
        //{
        //    int usuarioId = (int)obj.usuarioId.Value;
        //    var usuario = _context.Usuarios.FirstOrDefault(a => a.Id == usuarioId);

        //    try
        //    {
        //        tool.MontaLog(1, "LOGOUT REALIZADO COM SUCESSO", usuario.Id, "LOGOUT");
        //    }
        //    catch (Exception ex)
        //    {
        //        tool.MontaLog(1, "ERRO AO SAIR - " + ex.Message, usuario.Id, "ERRO");
        //    }
        //}
    }
}