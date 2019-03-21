using System;
using System.Collections.Generic;

namespace Senai.SpMedGroup.Domains
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }

        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public Medicos Medicos { get; set; }
        public Prontuarios Prontuarios { get; set; }
    }
}
