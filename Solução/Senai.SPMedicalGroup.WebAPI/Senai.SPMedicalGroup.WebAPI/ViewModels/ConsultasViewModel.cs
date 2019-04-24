using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.ViewModels
{
    public class ConsultasViewModel
    {
        public int Id { get; set; }
        public string PacienteNome { get; set; }
        public string PacienteEmail { get; set; }

        public string MedicoNome { get; set; }
        public string MedicoEmail { get; set; }

        public string Especialidade { get; set; }
        public string Descricao { get; set; }
        public string DataConsulta { get; set; }
        public string Preco { get; set; }
        public string Status { get; set; }
    }
}
