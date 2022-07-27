using ExoApi.Interfaces;
using ExoApi.Models;
using ExoApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ExoApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase

    {
        private readonly IUsuarioRepository _iUsuarioRepository;

        public LoginController(IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel dados)
        {
            try
            {
                Usuario usuarioEncontrado = _iUsuarioRepository.Login(dados.Email, dados.Senha);
                if (usuarioEncontrado == null)
                {
                    return Unauthorized(new { msg = "E-mail e/ou Senha incorreto" });
                }

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioEncontrado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioEncontrado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioEncontrado.Tipo)
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("exoapi-chave-autenticacao"));

                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                    issuer: "exoapi.webapi",
                    audience: "exoapi.webapi",
                    claims: minhasClaims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credenciais
                    );

                return Ok(
                        new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(meuToken),
                        }
                    );

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
