using System;
using System.IO;
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
        private EmailsController Email { get; set; }
        private IPacienteRepository PacienteRepository { get; set; }
        private IMedicoRepository MedicoRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
            Email = new EmailsController();
            PacienteRepository = new PacienteRepository();
            MedicoRepository = new MedicoRepository();
        }

        [HttpPost("administrador")]
        [Authorize(Roles = "Administrador")]
        public IActionResult CadastrarAdministrador([FromForm] AdministradorStandaloneViewModel usuarioModel)
        {
            try
            {
                CadastrarUsuarioViewModel usuario = UsuarioRepository.RetornarUsuarioViewModel(usuarioModel);

                if (usuario.FotoPerfil != null && usuario.FotoPerfil.Length > 0)
                {
                    string fileExt = Path.GetExtension(usuario.FotoPerfil.FileName);

                    if (fileExt != ".png" && fileExt != ".jpeg")
                    {
                        return BadRequest(new
                        {
                            mensagem = "Os únicos formatos de arquivo suportados são .jpeg e .png."
                        });
                    }
                }

                UsuarioRepository.CadastrarUsuario(usuario);

                Email.Enviar(UsuarioRepository.RetornarEmUsuarios(usuario));

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
        public IActionResult CadastrarMedico([FromForm] MedicoStandaloneViewModel medicoModel)
        {
            try
            {
                MedicoViewModel medico = MedicoRepository.RetornarMedicoViewModel(medicoModel);

                UsuarioRepository.CadastrarMedico(medico);
                Email.Enviar(UsuarioRepository.RetornarEmUsuarios(medico.UsuarioViewModel));

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
        public IActionResult CadastrarPaciente([FromForm] PacienteStandaloneViewModel pacienteModel)
        {
            try
            {
                PacienteViewModel paciente = PacienteRepository.RetornarPacienteViewModel(pacienteModel);

                if (paciente.Paciente.DataNascimento.Date > DateTime.Now.Date)
                {
                    return BadRequest(new
                    {
                        mensagem = "A data de nascimento do paciente não pode ser maior do que a data atual."
                    });
                }

                UsuarioRepository.CadastrarPaciente(paciente);
                Email.Enviar(UsuarioRepository.RetornarEmUsuarios(paciente.UsuarioViewModel));

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