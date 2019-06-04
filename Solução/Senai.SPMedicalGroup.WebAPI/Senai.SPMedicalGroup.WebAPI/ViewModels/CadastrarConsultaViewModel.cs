using Senai.SPMedicalGroup.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.ViewModels
{
    public class CadastrarConsultaViewModel
    {
        public Consultas Consulta { get; set; }
        public ConsultaLocalizacao ConsultaLocalizacao { get; set; }
    }
}
