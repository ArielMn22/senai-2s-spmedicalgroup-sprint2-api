using Senai.SPMedicalGroup.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.ViewModels
{
    public class MedicoViewModel
    {
        /// <summary>
        /// Guarda as informações referentes ao usuário.
        /// </summary>
        public CadastrarUsuarioViewModel UsuarioViewModel { get; set; }

        /// <summary>
        /// Guarda as informações referentes ao médico.
        /// </summary>
        public Medicos Medico { get; set; }
    }
}
