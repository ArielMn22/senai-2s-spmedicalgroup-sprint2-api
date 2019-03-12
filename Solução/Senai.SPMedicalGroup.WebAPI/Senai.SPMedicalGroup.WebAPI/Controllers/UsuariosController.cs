using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using Senai.SPMedicalGroup.WebAPI.Repositories;
using Senai.SPMedicalGroup.WebAPI.ViewModels;

namespace Senai.SPMedicalGroup.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpPost("administrador")]
        [Authorize(Roles = "Administrador")]
        public IActionResult CadastrarAdministrador(Usuarios usuario)
        {
            try
            {
                UsuarioRepository.CadastrarAdministrador(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }

        [HttpPost("medico")]
        [Authorize(Roles = "Administrador")]
        public IActionResult CadastrarMedico(MedicoViewModel medicoModel)
        {
            try
            {
                UsuarioRepository.CadastrarMedico(medicoModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }

        [HttpPost("paciente")]
        [Authorize(Roles = "Administrador")]
        public IActionResult CadastrarPaciente(PacienteViewModel pacienteModel)
        {
            try
            {
                if (pacienteModel.Paciente.DataNascimento.Date > DateTime.Now.Date)
                {
                    return BadRequest(new
                    {
                        mensagem = "A data de nasciemento do paciente não pode ser maior do que a data atual."
                    });
                }

                UsuarioRepository.CadastrarPaciente(pacienteModel);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }
    }
}