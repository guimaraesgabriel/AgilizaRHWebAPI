using AgilizaRH.Context;
using AgilizaRH.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebApi.Helpers;

namespace AgilizaRH.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AcessoApiController : ControllerBase
    {
        private readonly AgilizaRHContext _context;
        private readonly AppSettings _appSettings;

        public AcessoApiController(AgilizaRHContext context, IOptions<AppSettings> appSettings)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]Usuarios usuarios)
        {
            var user = _context.Usuarios.SingleOrDefault(x => x.Email == usuarios.Email && x.Senha == usuarios.Senha);

            // return null if user not found
            if (user == null)
                return BadRequest("Credenciais inválidas...");

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_appSettings.Secret);
            var token = new JwtSecurityToken
                (
                    claims: new[] { new Claim(ClaimTypes.Name, user.Id.ToString()) },
                    expires: DateTime.Now.AddYears(10),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                );
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });

        }
}
}
