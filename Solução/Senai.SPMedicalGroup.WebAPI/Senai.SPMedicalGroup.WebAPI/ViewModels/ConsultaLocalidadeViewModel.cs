using Senai.SPMedicalGroup.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.ViewModels
{
    public class ConsultaLocalidadeViewModel : ConsultasViewModel
    {
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
