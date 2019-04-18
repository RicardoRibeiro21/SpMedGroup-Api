using Senai.SpMedGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.Manha.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListaTiposUsuarios();
       
    }
}
