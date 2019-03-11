using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using Senai.SPMedicalGroup.WebAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;

namespace Senai.SPMedicalGroup.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository ConsultaRepository { get; set; }
        private IPacienteRepository PacienteRepository { get; set; }
        private IMedicoRepository MedicoRepository { get; set; }

        public ConsultasController()
        {
            ConsultaRepository = new ConsultaRepository();
            PacienteRepository = new PacienteRepository();
            MedicoRepository = new MedicoRepository();
        }

        [HttpGet]
        [Authorize(Roles = "Administrador")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(ConsultaRepository.ListarTodas());
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Cadastrar(Consultas consulta)
        {
            try
            {
                ConsultaRepository.Cadastrar(consulta);

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

        [HttpPut]
        [Authorize(Roles = "Administrador,Médico")]
        public IActionResult Atualizar(Consultas novaConsulta)
        {
            try
            {
                Consultas consultaCadastrada = ConsultaRepository.BuscarPorId(novaConsulta.Id);

                if (consultaCadastrada == null)
                {
                    return NotFound(new
                    {
                        mensagem = "A consulta informada não foi encontrada."
                    });
                }

                ConsultaRepository.Atualizar(novaConsulta, consultaCadastrada);
                
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
        
        [HttpGet("paciente")]
        [Authorize(Roles = "Paciente")]
        public IActionResult ListarPorPaciente()
        {
            try
            {
                int usuarioId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                Pacientes pacienteProcurado = PacienteRepository.BuscarPacientePorIdUsuario(usuarioId);

                if (pacienteProcurado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "Paciente não encontrado em nosso banco de dados."
                    });
                }
                
                return Ok(ConsultaRepository.ListarPorIdPaciente(pacienteProcurado.Id));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }

        [HttpGet("medico")]
        [Authorize(Roles = "Médico")]
        public IActionResult ListarPorMedico()
        {
            try
            {
                int usuarioId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                Medicos medicoProcurado = MedicoRepository.BuscarMedicoPorIdUsuario(usuarioId);

                if (medicoProcurado == null)
                {
                    return NotFound(new
                    {
                        mensagem = "O médico não foi encontrado."
                    });
                }

                return Ok(ConsultaRepository.ListarPorIdMedico(medicoProcurado.Id));
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