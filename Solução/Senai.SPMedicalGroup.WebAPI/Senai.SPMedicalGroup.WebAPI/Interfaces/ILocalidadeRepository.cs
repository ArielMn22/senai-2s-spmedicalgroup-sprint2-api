using Senai.SPMedicalGroup.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Interfaces
{
    public interface ILocalidadeRepository
    {
        /// <summary>
        /// Listar todas as localidades cadastradas no programa, apenas as localidades. Sem as consultas.
        /// </summary>
        /// <returns></returns>
        List<LocalidadeViewModel> Listar();
    }
}
