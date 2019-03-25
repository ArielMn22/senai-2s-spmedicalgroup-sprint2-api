using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.SPMedicalGroup.WebAPI.Interfaces;
using Senai.SPMedicalGroup.WebAPI.Repositories;

namespace Senai.SPMedicalGroup.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class StatusController : ControllerBase
    {
        private IStatusRepository StatusRepository { get; set; }

        public StatusController()
        {
            StatusRepository = new StatusRepository();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Listar()
        {
            try
            {
                return Ok(StatusRepository.ListarTodos());
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