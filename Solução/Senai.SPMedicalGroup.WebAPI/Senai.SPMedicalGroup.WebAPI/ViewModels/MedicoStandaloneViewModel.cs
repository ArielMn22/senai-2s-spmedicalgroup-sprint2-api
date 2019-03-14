using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.ViewModels
{
    public class MedicoStandaloneViewModel
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

        #region Medico
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdEspecialidade { get; set; }
        public string Crm { get; set; }
        #endregion
    }
}
