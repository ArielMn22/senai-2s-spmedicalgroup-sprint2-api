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
        /// Cadastra um usuário no banco de dados.
        /// </summary>
        /// <param name="usuario">Usuarios Object</param>
        void Cadastrar(Usuarios usuario);

        /// <summary>
        /// Busca um usuário por E-mail e Senha.
        /// </summary>
        /// <param name="login">LoginViewModel Object</param>
        /// <returns>Usuarios Object</returns>
        Usuarios BuscarPorEmailESenha(LoginViewModel login);
    }
}
