using Senai.SpMedGroup.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.Manha.Interfaces
{
    interface IUsuarioRepository
    {
        void Cadastrar(Usuarios usuario);

        void Atualizar(Usuarios usuario);

        List<Consultas> ListarConsultasDoUsuario(int id);

        List<Usuarios> ListaUsuarios();
    }
}
