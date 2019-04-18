using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SpMedGroup.Manha.Interfaces;
using Senai.SpMedGroup.Manha.Repositories;

namespace Senai.SpMedGroup.Manha.Controllers
{
    [System.Web.Http.Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private ITipoUsuario TipoUsuarioRepository { get; set; }
        public TipoUsuarioController()
        {
            TipoUsuarioRepository = new TipoUsuarioRepository();
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet]
        public IActionResult Listar()
        {
            TipoUsuarioRepository repositorio = new TipoUsuarioRepository();
            repositorio.
        }
    }
}