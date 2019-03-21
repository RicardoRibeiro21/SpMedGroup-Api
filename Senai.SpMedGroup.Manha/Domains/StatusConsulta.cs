using System;
using System.Collections.Generic;

namespace Senai.SpMedGroup.Domains
{
    public partial class StatusConsulta
    {
        public StatusConsulta()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        public string Situacao { get; set; }

        public ICollection<Consultas> Consultas { get; set; }
    }
}
