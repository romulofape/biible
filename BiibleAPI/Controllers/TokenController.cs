using Biible.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BiibleAPI.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] ApplicationUser request)
        {
            if (request.UserName == "Mac" && request.PasswordHash == "numsey")
            {
                Claim[] claims = new[]
                {
                    new  Claim(ClaimTypes.Name, request.UserName),
                    new  Claim(ClaimTypes.Role, "Admin")
                };

                //recebe uma instancia da classe SymmetricSecurityKey 
                //armazenando a chave de criptografia usada na criação do token
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                //recebe um objeto do tipo SigninCredentials contendo a chave de 
                //criptografia e o algoritmo de segurança empregados na geração 
                // de assinaturas digitais para tokens
                SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                JwtSecurityToken token = new JwtSecurityToken(
                     issuer: "biible.com.br",
                     audience: "biible.com.br",
                     claims: claims,
                     expires: DateTime.Now.AddMinutes(30),
                     signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            return BadRequest("Credenciais inválidas...");
        }
    }
}