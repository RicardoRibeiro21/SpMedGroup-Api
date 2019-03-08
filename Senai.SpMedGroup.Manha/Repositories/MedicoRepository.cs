using Senai.SpMedGroup.Manha.Domains;
using Senai.SpMedGroup.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.Manha.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        public void Cadastrar(Medicos medico)
        {
            using(SpMedGroupContext spmed = new SpMedGroupContext())
            {
                spmed.Medicos.Add(medico);
                spmed.SaveChanges();
            }
        }

        public List<Medicos> ListarMedicos() => new SpMedGroupContext().Medicos.ToList();
    }
}
