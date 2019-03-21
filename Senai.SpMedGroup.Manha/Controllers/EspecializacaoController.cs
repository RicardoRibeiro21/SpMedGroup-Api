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
    public class EspecializacaoController : ControllerBase
    {
        private IEspecializacaoRepository EspecializacaoRepository { get; set; }

        public EspecializacaoController()
        {
            EspecializacaoRepository = new EspecializacaoRepository();
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
               
                return Ok(EspecializacaoRepository.listarEspecializacoes());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost] 
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(Especializacoes especializacao)
        {
            try
            {
                EspecializacaoRepository.Cadastrar(especializacao);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult Put(Especializacoes especializacao)
        {
            try
            {
                EspecializacaoRepository.Atualizar(especializacao);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}