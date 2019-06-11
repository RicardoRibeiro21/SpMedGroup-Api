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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusConsultaController : ControllerBase
    {
        private IStatusConsulta StatusConsultaRepository { get; set; }
        
        public StatusConsultaController()
        {
            StatusConsultaRepository = new StatusConsultaRepository();
        }

        [Authorize(Roles = "Administrador, Medico")]
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                return Ok(StatusConsultaRepository.ListarStatusConsulta());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}