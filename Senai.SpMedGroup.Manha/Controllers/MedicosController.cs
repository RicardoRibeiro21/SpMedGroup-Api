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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository MedicoRepository { get; set; }
        public MedicosController()
        {
            MedicoRepository = new MedicoRepository();
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet] 
        public IActionResult Get()
        {
            try
            {
                return Ok(MedicoRepository.ListarMedicos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Medicos medico)
        {
            try
            {
                MedicoRepository.Cadastrar(medico);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Administrador, Medico")]
        [Route("minhasConsultas")]
        [HttpGet]
        public IActionResult ListarMinhasConsultas()
        {
            try
            {
                //Armazenando o crm do medico que está logado para retornar as consultas dele   
                int idMedico = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(MedicoRepository.ListarConsultasDoMedico(idMedico));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}