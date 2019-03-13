using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.ViewModels
{
    public class CadastrarUsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        // Foto de perfil
        public IFormFile FotoPerfil { get; set; }
        public int? IdTipoUsuario { get; set; }
        public int? IdClinica { get; set; }
    }
}
