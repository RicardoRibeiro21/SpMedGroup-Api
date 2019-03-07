using System;
using System.Collections.Generic;

namespace Senai.SpMedGroup.Manha.Domains
{
    public partial class Consultas
    {
        public int Id { get; set; }
        public string CrmMedico { get; set; }
        public DateTime DataConsulta { get; set; }
        public int StatusConsulta { get; set; }
        public int IdProntuario { get; set; }
        public string Resultado { get; set; }

        public Medicos CrmMedicoNavigation { get; set; }
        public Prontuarios IdProntuarioNavigation { get; set; }
        public StatusConsulta StatusConsultaNavigation { get; set; }
    }
}
