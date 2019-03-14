using Senai.SpMedGroup.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.Manha.Interfaces
{
    interface IMedicoRepository
    {
        void Cadastrar(Medicos medico);

        List<Medicos> ListarMedicos();

        List<Consultas> ListarConsultasDoMedico(string crmMedico);
    }
}
