using Senai.SPMedicalGroup.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Interfaces
{
    public interface IStatusRepository
    {
        /// <summary>
        /// Lista todos os tipos de status cadastrados
        /// </summary>
        /// <returns>Ums lista de 'TipoStatus'</returns>
        List<TipoStatus> ListarTodos();
    }
}
