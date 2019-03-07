using System;
using System.Collections.Generic;

namespace Senai.SpMedGroup.Manha.Domains
{
    public partial class Medicos
    {
        public Medicos()
        {
            Consultas = new HashSet<Consultas>();
        }

        public string Crm { get; set; }
        public string Nome { get; set; }
        public int IdEspecializacao { get; set; }
        public int IdClinica { get; set; }
        public string Email { get; set; }

        public Clinica IdClinicaNavigation { get; set; }
        public Especializacoes IdEspecializacaoNavigation { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}
