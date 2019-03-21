using System;
using System.Collections.Generic;

namespace Senai.SpMedGroup.Domains
{
    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Tipo { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
