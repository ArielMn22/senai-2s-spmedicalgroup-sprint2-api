using System;
using System.Collections.Generic;

namespace Senai.SPMedicalGroup.WebAPI.Domains
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            Medicos = new HashSet<Medicos>();
            Pacientes = new HashSet<Pacientes>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdClinica { get; set; }
        public string Fotoperfil { get; set; }

        public Clinica IdClinicaNavigation { get; set; }
        public TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public ICollection<Medicos> Medicos { get; set; }
        public ICollection<Pacientes> Pacientes { get; set; }
    }
}
