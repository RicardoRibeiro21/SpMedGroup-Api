using Senai.SpMedGroup.Domains;
using System.Collections.Generic;

namespace Senai.SpMedGroup.Manha.Interfaces
{
    interface IUsuarioRepository
    {
        void Cadastrar(Usuarios usuario);

        void Atualizar(Usuarios usuario);

        List<Consultas> ListarConsultasDoUsuario(int id);

        List<Usuarios> ListaUsuarios();

        Usuarios BuscarPorEmailSenha(string email, string senha);
    }
}
