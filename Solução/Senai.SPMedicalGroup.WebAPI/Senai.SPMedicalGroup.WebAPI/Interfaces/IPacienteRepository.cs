using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.ViewModels;
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

        /// <summary>
        /// Retorna um PacienteViewModel a partir de um PacienteStandaloneViewModel
        /// </summary>
        /// <param name="pacienteModel"></param>
        /// <returns></returns>
        PacienteViewModel RetornarPacienteViewModel(PacienteStandaloneViewModel pacienteModel);

        /// <summary>
        /// Lista os pacientes cadastrados no sistema.
        /// </summary>
        /// <returns>Retornar uma lista de pacientes.</returns>
        List<Pacientes> ListarPacientes();
    }
}
