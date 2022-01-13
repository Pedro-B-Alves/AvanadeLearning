using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Domains;
using avanadeLearning_webApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class RespostasController : ControllerBase
    {
        private IBaseRepository<Respostum> _RespostaRepository { get; set; }

        public RespostasController()
        {
            _RespostaRepository = new RespostaRepository();
        }

        // Role = 1 para Admin 
        // Role = 2 para Prof 
        [Authorize(Roles = "1,2")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_RespostaRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_RespostaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // Role = 2 para Prof 
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Respostum novaResposta)
        {
            try
            {
                _RespostaRepository.Cadastrar(novaResposta);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Role = 1 para Admin 
        // Role = 2 para Prof 
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Respostum RespostaAtualizada)
        {
            try
            {
                _RespostaRepository.Atualizar(id, RespostaAtualizada);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        // Role = 1 para Admin 
        // Role = 2 para Prof 
        [Authorize(Roles = "1,2")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _RespostaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
