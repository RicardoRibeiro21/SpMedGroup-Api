using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SpMedGroup.Manha.Domains;
using Senai.SpMedGroup.Manha.Interfaces;
using Senai.SpMedGroup.Manha.Repositories;

namespace Senai.SpMedGroup.Manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository ConsultaRepository { get; set; }

        public ConsultasController()
        {
            ConsultaRepository = new ConsultaRepository();
        }
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