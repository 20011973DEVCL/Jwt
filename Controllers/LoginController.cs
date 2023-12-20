using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Jwt.Constants;
using Jwt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Jwt.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config)
        {
            this._config = config;   
        }


        [HttpPost]
        public IActionResult Login(LoginUser userLogin)
        {
            var user = Authenticate(userLogin);
            if (user!=null)
            {
                //Crear Token

                // var token= Generate
                return Ok("Usuario Logueado");
            }

            return NotFound("Usuario no Encontrado");
        }

        private UserModel Authenticate(LoginUser userLogin)
        {
         
            var currentUser = UserConstants.users.FirstOrDefault( user => user.Username.ToLower() == userLogin.Username.ToLower()
                && user.Password == userLogin.Password);
            
            if (currentUser != null)
            {
                return currentUser;
            }
            
            return null;
        }

        private string Generate(UserModel user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            
            //Crear Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.EmailAdrress),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Rol)
            };
            //Crear Token
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
        }
    }
}