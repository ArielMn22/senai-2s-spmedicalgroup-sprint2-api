using Senai.SPMedicalGroup.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Interfaces
{
    public interface IPacienteRepository
    {
        /// <summary>
        /// Busca um paciente por meio de seu IdUsuario.
        /// </summary>
        /// <param name="idUsuario">Id do usuário que está relacionado com o paciente.</param>
        /// <returns>Um Paciente</returns>
        Pacientes BuscarPacientePorIdUsuario(int idUsuario);
    }
}
