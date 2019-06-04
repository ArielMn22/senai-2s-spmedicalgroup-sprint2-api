using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using Senai.SPMedicalGroup.WebAPI.Repositories;

namespace Senai.SPMedicalGroup.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class LocalidadesController : ControllerBase
    {
        private ILocalidadeRepository LocalidadeRepository { get; set; }

        public LocalidadesController()
        {
            LocalidadeRepository = new LocalidadeRepository();
        }

        [HttpGet]
        public IActionResult ListarLocalidades()
        {
            try
            {
                return Ok(LocalidadeRepository.Listar());
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