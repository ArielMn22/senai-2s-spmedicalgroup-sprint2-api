using Senai.SPMedicalGroup.WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.ViewModels
{
    public class PacienteViewModel
    {
        /// <summary>
        /// Guarda as informações referentes ao usuário. Como Email, Senha, IdClinica.
        /// </summary>
        public CadastrarUsuarioViewModel UsuarioViewModel { get; set; }

        /// <summary>
        /// Guarda as informações referentes ao paciente. Como Nome, DataNascimento, Telefone.
        /// </summary>
        public Pacientes Paciente { get; set; }
    }
}
