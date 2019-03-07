using System;
using System.Collections.Generic;

namespace Senai.SpMedGroup.Manha.Domains
{
    public partial class Usuarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }

        public TipoUsuario TipoUsuario { get; set; }
        public Prontuarios Prontuarios { get; set; }
    }
}
