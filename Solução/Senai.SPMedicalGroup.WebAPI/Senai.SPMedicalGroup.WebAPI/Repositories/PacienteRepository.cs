using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        public Pacientes BuscarPacientePorIdUsuario(int idUsuario)
        {
            using (SPMedGroupContext ctx = new SPMedGroupContext())
            {
                return ctx.Pacientes.FirstOrDefault(x => x.IdUsuario == idUsuario);
            }
        }
    }
}
