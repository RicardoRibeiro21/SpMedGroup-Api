using System;
using System.Collections.Generic;

namespace Senai.SpMedGroup.Domains
{
    public partial class Medicos
    {
        public Medicos()
        {
            Consultas = new HashSet<Consultas>();
        }

        public string Crm { get; set; }
        public int IdUsuario { get; set; }
        public int IdEspecializacao { get; set; }
        public int IdClinica { get; set; }

        public Clinica IdClinicaNavigation { get; set; }
        public Especializacoes IdEspecializacaoNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}
