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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
             
                return Ok(UsuarioRepository.ListaUsuarios());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("minhasConsultas")]
        [HttpGet("{id}")]
        public IActionResult ListarMinhasConsultas(int id)
        {
            try
            {
                return Ok(UsuarioRepository.ListarConsultasDoUsuario(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.Atualizar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}