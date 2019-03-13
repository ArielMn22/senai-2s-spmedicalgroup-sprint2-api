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
        /// Cadastra um usuário no banco de dados, o mesmo que cadastrar um administrador.
        /// </summary>
        /// <param name="usuario">Usuarios Object</param>
        void CadastrarUsuario(CadastrarUsuarioViewModel usuario);

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

        /// <summary>
        /// Retorna um Usuarios a partir da VIewModel.
        /// </summary>
        /// <param name="usuarioViewModel"></param>
        /// <returns></returns>
        Usuarios RetornarEmUsuarios(CadastrarUsuarioViewModel usuarioViewModel);

        /// <summary>
        /// Retorna um CadastrarUsuarioViewModel a partir de um AdministradorStandaloneViewModel
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        CadastrarUsuarioViewModel RetornarUsuarioViewModel(AdministradorStandaloneViewModel usuarioModel);
    }
}
