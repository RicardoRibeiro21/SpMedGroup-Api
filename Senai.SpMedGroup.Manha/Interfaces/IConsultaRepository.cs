using Senai.SpMedGroup.Domains;
using System.Collections.Generic;

namespace Senai.SpMedGroup.Manha.Interfaces
{
    interface IConsultaRepository
    {
        void Cadastrar(Consultas consultas);
        //void AtualizarAdm(Consultas consultas);
        void AtualizarResultado(Consultas consulta);

        void Deletar(int id);

        List<Consultas> ListarConsultas();
      
  
    }
}
