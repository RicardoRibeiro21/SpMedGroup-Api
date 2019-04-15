using Senai.SpMedGroup.Domains;
using System.Collections.Generic;

namespace Senai.SpMedGroup.Manha.Interfaces
{
    interface IMedicoRepository
    {
        void Cadastrar(Medicos medico);

        List<Medicos> ListarMedicos();

        List<Consultas> ListarConsultasDoMedico(int idMedico);
    }
}
