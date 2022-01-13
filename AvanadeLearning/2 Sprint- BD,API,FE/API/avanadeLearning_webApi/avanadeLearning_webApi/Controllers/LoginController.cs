using avanadeLearning_webApi.Domains;
using avanadeLearning_webApi.Interfaces;
using avanadeLearning_webApi.Repositories;
using avanadeLearning_webApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
                Usuario usuario = _usuarioRepository.BuscarPorEmail(login.Email);

                if(usuario != null)
                {
                    if (!Validar(login.Senha, usuario.Senha))
                        {
                            return NotFound("E-mail ou senha inválidos!");
                        }
                }
                

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),

                    new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),

                    new Claim(ClaimTypes.Role, usuario.IdTipoUsuario.ToString()),

                    new Claim("role", usuario.IdTipoUsuario.ToString()),

                    new Claim("nome", usuario.Nome),

                    new Claim("imagem", usuario.Imagem)

                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("avanadeLearning-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gera o token
                var token = new JwtSecurityToken(
                    issuer: "avanadeLearning.webApi",
                    audience: "avanadeLearning.webApi",
                    claims: claims,
                    expires: DateTime.Now.AddHours(6),
                    signingCredentials: creds
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private bool Validar(string senha1, string senha2)
        {
            return BCrypt.Net.BCrypt.Verify(senha1, senha2);
        }
    }
}
