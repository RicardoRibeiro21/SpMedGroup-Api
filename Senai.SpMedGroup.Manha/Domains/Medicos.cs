using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.SpMedGroup.Manha.Domains
{
    public partial class Medicos
    {
        public Medicos()
        {
            Consultas = new HashSet<Consultas>();
        }
        [Required(ErrorMessage = "Informe o crm do médico.")]
        [StringLength(8, ErrorMessage = "Este campo deve conter 8 caracteres.")]
        public string Crm { get; set; }
        [Required(ErrorMessage = "Informe a especialização do médico.")]
        public int IdEspecializacao { get; set; }
        [Required(ErrorMessage = "Informe a clínica.")]
        public int IdClinica { get; set; }
        [Required(ErrorMessage = "Informe o email do médico.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Usuarios IdUsuarioNavigation { get; set; }
        public Clinica IdClinicaNavigation { get; set; }
        public Especializacoes IdEspecializacaoNavigation { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}
