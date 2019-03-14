using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.ViewModels
{
    public class PacienteStandaloneViewModel
    {
        #region CadastrarUsuarioViewModel
        public int IdUsuarioViewModel { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        // Foto de perfil
        public IFormFile FotoPerfil { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdClinica { get; set; }
        #endregion

        #region Paciente
        public int IdPaciente { get; set; }
        public int? IdUsuario { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        #endregion
    }
}
