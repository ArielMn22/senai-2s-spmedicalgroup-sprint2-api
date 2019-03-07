using System;
using System.Collections.Generic;

namespace Senai.SPMedicalGroup.WebAPI.Domains
{
    public partial class TipoStatus
    {
        public TipoStatus()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Consultas> Consultas { get; set; }
    }
}
