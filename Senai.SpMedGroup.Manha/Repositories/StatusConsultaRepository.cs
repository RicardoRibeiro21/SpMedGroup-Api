using Senai.SpMedGroup.Domains;
using Senai.SpMedGroup.Manha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SpMedGroup.Manha.Repositories
{
    public class StatusConsultaRepository : IStatusConsulta
    {
        public List<StatusConsulta> ListarStatusConsulta() => new SpMedGroupContext().StatusConsulta.ToList();
  
    }
}
