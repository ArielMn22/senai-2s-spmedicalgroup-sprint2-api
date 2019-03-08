using Senai.SPMedicalGroup.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Interfaces
{
    public interface IClinicaRepository
    {
        /// <summary>
        /// Cadastra os dados de uma clínica.
        /// </summary>
        /// <param name="clinica"></param>
        void CadastrarDados(Clinica clinica);

        /// <summary>
        /// Atualiza os dados da clínica.
        /// </summary>
        /// <param name="clinica">Objeto do tipo clinica.</param>
        void AtualizarDados(Clinica clinica);
    }
}
