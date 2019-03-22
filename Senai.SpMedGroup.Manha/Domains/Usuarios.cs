using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Senai.SpMedGroup.Domains
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe o nome do usuário.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o tipo de usuário")]
        public int IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "Informe o email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Informe a senha.")]
        public string Senha { get; set; }
        [Required(ErrorMessage = "Informe a data de nascimento.")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public Medicos Medico { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Prontuarios Prontuarios { get; set; }
    }
}
