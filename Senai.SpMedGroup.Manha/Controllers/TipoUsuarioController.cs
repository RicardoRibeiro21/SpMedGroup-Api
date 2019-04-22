using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SpMedGroup.Domains;
using Senai.SpMedGroup.Manha.Interfaces;
using Senai.SpMedGroup.Manha.Repositories;

namespace Senai.SpMedGroup.Manha.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuarioRepository TipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            TipoUsuarioRepository = new TipoUsuarioReporitory();
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                TipoUsuarioReporitory repositorio = new TipoUsuarioReporitory();
                return Ok(repositorio.ListaTiposUsuarios());
            }
            catch (Exception ex){

                return BadRequest(ex);

            }
        }
    }
}
