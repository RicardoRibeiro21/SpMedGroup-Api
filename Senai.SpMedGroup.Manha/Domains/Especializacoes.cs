using System;
using System.Collections.Generic;

namespace Senai.SpMedGroup.Manha.Domains
{
    public partial class Especializacoes
    {
        public Especializacoes()
        {
            Medicos = new HashSet<Medicos>();
        }

        public int Id { get; set; }
        public string Especializacao { get; set; }

        public ICollection<Medicos> Medicos { get; set; }
    }
}
