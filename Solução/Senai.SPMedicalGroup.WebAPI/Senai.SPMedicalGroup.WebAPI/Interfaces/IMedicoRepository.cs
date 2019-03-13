using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Interfaces
{
    public interface IMedicoRepository
    {
        /// <summary>
        /// Busca um médico por meio do id do usuário.
        /// </summary>
        /// <param name="Idusuario">Id do usuário relacionado com o médico.</param>
        /// <returns>Um Objeto Medicos</returns>
        Medicos BuscarMedicoPorIdUsuario(int Idusuario);

        /// <summary>
        /// Retorna um MedicoViewModel a partir de um MedicoStandaloneViewModel
        /// </summary>
        /// <returns></returns>
        MedicoViewModel RetornarMedicoViewModel(MedicoStandaloneViewModel medicoModel);
    }
}
