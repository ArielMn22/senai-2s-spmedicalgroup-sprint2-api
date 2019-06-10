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
using System.Security.Claims;
using Senai.SPMedicalGroup.WebAPI.ViewModels;

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
        //[Authorize(Roles = "Administrador")]
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
        public IActionResult Cadastrar(CadastrarConsultaViewModel consultaViewModel)
        {
            try
            {
                if (ConsultaRepository.ValidarConsulta(consultaViewModel.Consulta))
                {
                    int idConsulta = ConsultaRepository.Cadastrar(consultaViewModel.Consulta);

                    consultaViewModel.ConsultaLocalizacao.IdConsulta = idConsulta;

                    ConsultaRepository.CadastrarConsultaLocalidade(consultaViewModel.ConsultaLocalizacao);
                    return Ok();
                }
                else
                {
                    return BadRequest(new
                    {
                        mensagem = "Consulta não pode ser cadastrada, provavelmente a data informada já foi cadastrada em uma consulta, adicione um intervalo de 31 minutos e tente novamente."
                    });
                }
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
        //[Authorize(Roles = "Paciente")]
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

        [HttpGet("listarporusuariologado")]
        [Authorize]
        public IActionResult ListarPorLogado()
        {
            try
            {
                int usuarioId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                string usuarioTipo = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value.ToString();

                if (usuarioTipo == "Médico")
                {
                    Medicos medicoProcurado = MedicoRepository.BuscarMedicoPorIdUsuario(usuarioId);
                    return Ok(ConsultaRepository.ListarPorIdMedico(medicoProcurado.Id));
                }
                else if (usuarioTipo == "Paciente")
                {
                    Pacientes pacienteProcurado = PacienteRepository.BuscarPacientePorIdUsuario(usuarioId);
                    return Ok(ConsultaRepository.ListarPorIdPaciente(pacienteProcurado.Id));
                }
                else if (usuarioTipo == "Administrador")
                {
                    return Ok(ConsultaRepository.ListarTodas());
                }
                else
                {
                    return BadRequest(new
                    {
                        mensagem = "Não foi possível listar, verifique se está logado como paciente, médico ou administrador."
                    });
                }

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

        [HttpPost("mongo")]
        public IActionResult CadastrarConsultaLocalizacao(ConsultaLocalizacao consulta)
        {
            try
            {
                ConsultaRepository.CadastrarConsultaLocalidade(consulta);
                return Ok(); //Implementar
            }
            catch (Exception ex)
            {

                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }

        [HttpGet("mongo")]
        public IActionResult ListarConsultasLocalizacao()
        {
            try
            {
                return Ok(ConsultaRepository.ListarConsultasLocalidade());
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Error: " + ex
                });
            }
        }

        [Authorize]
        [HttpGet("mongoLogado")]
        public IActionResult ListarConsultaLocalizacaoLogado()
        {
            try
            {
                int usuarioId = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                string usuarioTipo = HttpContext.User.Claims.First(c => c.Type == ClaimTypes.Role).Value.ToString();

                if (usuarioTipo == "Médico")
                {
                    Medicos medicoProcurado = MedicoRepository.BuscarMedicoPorIdUsuario(usuarioId);
                    return Ok(ConsultaRepository.ListarConsultasLocalidadePorMedico(medicoProcurado));
                }
                else if (usuarioTipo == "Paciente")
                {
                    Pacientes pacienteProcurado = PacienteRepository.BuscarPacientePorIdUsuario(usuarioId);
                    return Ok(ConsultaRepository.ListarConsultasLocalidadePorPaciente(pacienteProcurado));
                }
                else if (usuarioTipo == "Administrador")
                {
                    return Ok(ConsultaRepository.ListarConsultasLocalidade());
                }
                else
                {
                    return BadRequest(new
                    {
                        mensagem = "Não foi possível listar, verifique se está logado como paciente, médico ou administrador."
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = ex
                });
            }
        }
    }
}