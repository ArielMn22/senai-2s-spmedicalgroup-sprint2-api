using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Cadastra um administrador no banco de dados.
        /// </summary>
        /// <param name="usuario">Usuarios Object</param>
        void CadastrarAdministrador(Usuarios usuario);

        /// <summary>
        /// Cadastra um paciente no banco de dados.
        /// </summary>
        /// <param name="usuario">PacienteViewModel Object</param>
        void CadastrarPaciente(PacienteViewModel pacienteModel);

        /// <summary>
        /// Cadastra um médico no banco de dados.
        /// </summary>
        /// <param name="usuario">MedicoViewModel Object</param>
        void CadastrarMedico(MedicoViewModel medicoModel);

        /// <summary>
        /// Busca um usuário por E-mail e Senha.
        /// </summary>
        /// <param name="login">LoginViewModel Object</param>
        /// <returns>Usuarios Object</returns>
        Usuarios BuscarPorEmailESenha(LoginViewModel login);
    }
}
