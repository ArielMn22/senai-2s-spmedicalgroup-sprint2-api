using Senai.SPMedicalGroup.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Interfaces
{
    public interface IEspecialidadeRepository
    {
        /// <summary>
        /// Lista todas as especialidades cadastradas no sistema.
        /// </summary>
        /// <returns>Uma List<Especialidades></returns>
        List<Especialidades> ListarTodas();

        /// <summary>
        /// Cadastra uma especialidade
        /// </summary>
        /// <param name="especialidade">Uma objeto 'Especialidades'</param>
        void Cadastrar(Especialidades especialidade);
    }
}
