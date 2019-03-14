using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.SpMedGroup.Manha.Domains
{
    public partial class Consultas
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o crm do médico")]
        [StringLength(8, ErrorMessage = "O campo deve ter apenas 8 caracteres")]
        public string CrmMedico { get; set; }
        [Required(ErrorMessage = "Informe a data da consulta")]
        [DataType(DataType.Date, ErrorMessage = "Informe uma data válida")]
        public DateTime DataConsulta { get; set; }
        [Required(ErrorMessage = "Informe o status da consulta")]
        public int StatusConsulta { get; set; }
        [Required(ErrorMessage = "Informe o Id do Prontuário")]
        public int IdProntuario { get; set; }
        public string Resultado { get; set; }

        public Medicos CrmMedicoNavigation { get; set; }
        public Prontuarios IdProntuarioNavigation { get; set; }
        public StatusConsulta StatusConsultaNavigation { get; set; }
    }
}
