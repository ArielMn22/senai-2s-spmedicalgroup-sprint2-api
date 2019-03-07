using Senai.SPMedicalGroup.WebAPI.Domains;
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

        Usuarios BuscarPorEmailESenha(LoginViewModel login);
    }
}
