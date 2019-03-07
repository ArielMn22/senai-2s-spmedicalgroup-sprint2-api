using System;
using System.Collections.Generic;

namespace Senai.SPMedicalGroup.WebAPI.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string HorarioFuncionamento { get; set; }
        public string Localidade { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
