using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.SpMedGroup.Domains;
using Senai.SpMedGroup.Manha.Interfaces;
using Senai.SpMedGroup.Manha.Repositories;

namespace Senai.SpMedGroup.Manha.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository ConsultaRepository { get; set; }

        public ConsultasController()
        {
            ConsultaRepository = new ConsultaRepository();
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(ConsultaRepository.ListarConsultas());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public IActionResult Post(Consultas consulta)
        {
            try
            {
                ConsultaRepository.Cadastrar(consulta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Administrador, Medicos")]
        [HttpPut]
        public IActionResult Atualizar(Consultas consulta)
        {
            try
            {
                ConsultaRepository.AtualizarResultado(consulta);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut]
        //public IActionResult Put(Consultas consulta)
        //{
        //    try
        //    {
        //        ConsultaRepository.AtualizarAdm(consulta);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

    }
}