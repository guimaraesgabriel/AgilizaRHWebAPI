using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AgilizaRH.Context;
using AgilizaRH.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Helpers;

namespace WebApi.Services
{
    public interface IUserService
    {
        Usuarios Authenticate(string username, string password);
        IEnumerable<Usuarios> GetAll();
    }


    public class UserService
    {
        private readonly AgilizaRHContext _context;

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, AgilizaRHContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public string Authenticate(string username, string password)
        {
            var user = _context.Usuarios.SingleOrDefault(x => x.Email == username && x.Senha == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(9999),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //user.Token = tokenHandler.WriteToken(token);

            return tokenHandler.WriteToken(token);
        }
    }
}