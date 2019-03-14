using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.SpMedGroup.Manha.Domains;
using Senai.SpMedGroup.Manha.Interfaces;
using Senai.SpMedGroup.Manha.Repositories;
using Senai.SpMedGroup.Manha.Views;

namespace Senai.SpMedGroup.Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }
        public LoginController()
        {
            UsuarioRepository = new UsuarioRepository();
            MedicoRepository = new MedicoRepository();
        }
        private IMedicoRepository MedicoRepository { get; set; }
        
        [HttpPost]
        public IActionResult Post(LoginViewModel login)
        {
            try
            {
 
                Usuarios usuarioBuscado = UsuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);
                if (usuarioBuscado == null)

                    return NotFound(new
                    {
                        mensagem = "Email ou senha inválido"
                    });
                //SENTA QUE LÁ VEM MERDA 2.0
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.Id.ToString()),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("sp-med-group-authentication"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                       //Nome do Issuer, de onde esta vindo
                       issuer: "SpMedGroup.Manha",
                     //Nome da Audience, de onde está vindo
                     audience: "SpMedGroup.Manha",
                     claims: claims,
                     expires: DateTime.Now.AddMinutes(40),
                     signingCredentials: creds

                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
                //Pode descansar agora meu rapaz 2.0
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}