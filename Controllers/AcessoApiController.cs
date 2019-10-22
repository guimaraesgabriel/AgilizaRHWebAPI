using AgilizaRH.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace AgilizaRH.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AcessoApiController : ControllerBase
    {
        private readonly IUserService _userService;
        public AcessoApiController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]Usuarios model)
        {
            var user = _userService.Authenticate(model.Email, model.Senha);

            if (user == null)
                return BadRequest(new { message = "E-mail ou senha incorreta." });

            return Ok(user);
        }
    }
}