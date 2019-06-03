using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Domains
{
    public class ConsultaLocalizacao
    {
        //Domain criado para o cadastro de localizações de onde as consultas serão realizadas.

        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int idConsulta { get; set; }
    }
}
