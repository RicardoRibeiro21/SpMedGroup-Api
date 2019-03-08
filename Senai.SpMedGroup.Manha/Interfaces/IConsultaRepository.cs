using Senai.SpMedGroup.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.Manha.Interfaces
{
    interface IConsultaRepository
    {
        void Cadastrar(Consultas consultas);
        //void AtualizarAdm(Consultas consultas);
        void AtualizarResultado(Consultas consulta);
        void Deletar(int id);
        List<Consultas> ListarConsultas();
        List<Consultas> ListarConsultasDoMedico();
        List<Consultas> ListarConsultasDoUsuario();
    }
}
