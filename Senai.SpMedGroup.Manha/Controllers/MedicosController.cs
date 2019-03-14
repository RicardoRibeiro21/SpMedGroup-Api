using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SpMedGroup.Manha.Domains;
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


        [Route("minhas")]
        [HttpGet("{crmMedico}")]
        public IActionResult ListarMinhasConsultas(string crmMedico)
        {
            try
            {
                return Ok(MedicoRepository.ListarConsultasDoMedico(crmMedico));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}