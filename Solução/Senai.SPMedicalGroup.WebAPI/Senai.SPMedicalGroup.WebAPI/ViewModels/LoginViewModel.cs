using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.SPMedicalGroup.WebAPI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "É necessário um e-mail para que seja efetuado o login no sistema.")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "O e-mail deve ter entre 5 e 255 caractéres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário uma senha para que seja efetuado o login no sistema.")]
        [StringLength(255, MinimumLength = 5, ErrorMessage = "A senha deve ter entre 5 e 255 caractéres.")]
        public string Senha { get; set; }
    }
}