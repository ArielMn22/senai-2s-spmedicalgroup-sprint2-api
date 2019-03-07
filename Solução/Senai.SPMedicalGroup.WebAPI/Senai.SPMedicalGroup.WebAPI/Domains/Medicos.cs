using System;
using System.Collections.Generic;

namespace Senai.SPMedicalGroup.WebAPI.Domains
{
    public partial class Medicos
    {
        public Medicos()
        {
            Consultas = new HashSet<Consultas>();
        }

        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEspecialidade { get; set; }
        public string Crm { get; set; }

        public Especialidades IdEspecialidadeNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
        public ICollection<Consultas> Consultas { get; set; }
    }
}
