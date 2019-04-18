using Senai.SpMedGroup.Domains;
using Senai.SpMedGroup.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.Manha.Repositories
{
    public class TipoUsuarioReporitory : ITipoUsuarioRepository
    {
        public List<TipoUsuario> ListaTiposUsuarios() => new SpMedGroupContext().TipoUsuario.ToList();
    }
}
