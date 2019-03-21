using Senai.SpMedGroup.Domains;
using System.Collections.Generic;

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
