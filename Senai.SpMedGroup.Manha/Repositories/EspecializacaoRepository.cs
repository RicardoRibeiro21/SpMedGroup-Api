using Senai.SpMedGroup.Domains;
using Senai.SpMedGroup.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.Manha.Repositories
{
    public class EspecializacaoRepository : IEspecializacaoRepository
    {
        public void Atualizar(Especializacoes especializacao)
        {
            using (SpMedGroupContext spmed = new SpMedGroupContext())
            {
                spmed.Especializacoes.Update(especializacao);
                spmed.SaveChanges();
            }
        }

        public void Cadastrar(Especializacoes especializacao)
        {
            using (SpMedGroupContext spmed = new SpMedGroupContext())
            {
                spmed.Especializacoes.Add(especializacao);
                spmed.SaveChanges();
            }
        }

        public void Deletar(int id)
        {

                ///Fazer método de deletar especializações
        }

        public List<Especializacoes> listarEspecializacoes() => new SpMedGroupContext().Especializacoes.ToList();
    }
}

