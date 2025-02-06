using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication_JwtAuth.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthModel model)
        {
            if (model.Username == "test" && model.Password == "123123")
            {
                return Ok(TokenService.GenerateToken(model.Username));
            
            }
            return BadRequest("Kullanıcı adı ya da şifre hatalı");
        }
    }

    public class AuthModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
