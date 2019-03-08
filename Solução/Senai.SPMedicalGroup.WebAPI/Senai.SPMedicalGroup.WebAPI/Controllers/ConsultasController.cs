using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SPMedicalGroup.WebAPI.Domains;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using Senai.SPMedicalGroup.WebAPI.Repositories;

namespace Senai.SPMedicalGroup.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository ConsultaRepository { get; set; }

        public ConsultasController()
        {
            ConsultaRepository = new ConsultaRepository();
        }

        [HttpGet]
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

        [HttpGet("paciente/{id}")]
        public IActionResult ListarPorPaciente(int id)
        {
            try
            {
                return Ok(ConsultaRepository.ListarPorIdPaciente(id));
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Erro: " + ex
                });
            }
        }

        [HttpGet("medico/{id}")]
        public IActionResult ListarPorMedico(int id)
        {
            try
            {
                return Ok(ConsultaRepository.ListarPorIdMedico(id));
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