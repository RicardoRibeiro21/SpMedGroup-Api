using Senai.SpMedGroup.Manha.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.Manha.Interfaces
{
    interface IEspecializacaoRepository
    {
        void Cadastrar(Especializacoes especializacao);
        void Atualizar(Especializacoes especializacao);
        void Deletar(int id);
        List<Especializacoes> listarEspecializacoes();
    }
}
