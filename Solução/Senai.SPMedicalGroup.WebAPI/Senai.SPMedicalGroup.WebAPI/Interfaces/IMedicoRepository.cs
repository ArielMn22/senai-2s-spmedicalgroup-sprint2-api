using Senai.SPMedicalGroup.WebAPI.Domains;
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
    }
}
