using System;
using System.Collections.Generic;

namespace Senai.SPMedicalGroup.WebAPI.Domains
{
    public partial class Consultas
    {
        public int Id { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public DateTime DataConsulta { get; set; }
        public string Observacoes { get; set; }
        public int IdStatus { get; set; }

        public Medicos IdMedicoNavigation { get; set; }
        public Pacientes IdPacienteNavigation { get; set; }
        public TipoStatus IdStatusNavigation { get; set; }
    }
}
