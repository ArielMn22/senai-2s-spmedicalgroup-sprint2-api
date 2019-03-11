using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using Senai.SPMedicalGroup.WebAPI.Repositories;

namespace Senai.SPMedicalGroup.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository ClinicaRepository { get; set; }

        public ClinicasController()
        {
            ClinicaRepository = new ClinicaRepository();
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(Clinica clinica)
        {
            try
            {
                ClinicaRepository.CadastrarDados(clinica);
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

        [Authorize(Roles = "Administrador")]
        [HttpPut]
        public IActionResult Atualizar(Clinica novaClinica)
        {
            try
            {
                Clinica clinicaCadastrada = ClinicaRepository.BuscarClinicaPorId(novaClinica.Id);

                if (clinicaCadastrada == null)
                {
                    return NotFound(new
                    {
                        mensagem = "A clínica não foi encontrada em nosso sistema."
                    });
                }

                ClinicaRepository.AtualizarDados(novaClinica, clinicaCadastrada);

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