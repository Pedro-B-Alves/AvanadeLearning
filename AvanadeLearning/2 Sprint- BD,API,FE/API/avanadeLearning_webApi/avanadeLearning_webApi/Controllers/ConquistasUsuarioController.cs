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
    public class ConquistasUsuarioController : ControllerBase
    {
        private IBaseRepository<ConquistaUsuario> _ConquistaUsuarioRepository { get; set; }

        public ConquistasUsuarioController()
        {
            _ConquistaUsuarioRepository = new ConquistaUsuarioRepository();
        }

        // Role = 1 para Admin  
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ConquistaUsuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_ConquistaUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // Role = 3 para Aluno 
        [Authorize(Roles = "3")]
        [HttpPost]
        public IActionResult Post(ConquistaUsuario novoConquistaUsuario)
        {
            try
            {
                _ConquistaUsuarioRepository.Cadastrar(novoConquistaUsuario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Role = 3 para Aluno 
        [Authorize(Roles = "3")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, ConquistaUsuario ConquistaUsuarioAtualizado)
        {
            try
            {
                _ConquistaUsuarioRepository.Atualizar(id, ConquistaUsuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Role = 1 para Admin 
        // Role = 3 para Aluno 
        [Authorize(Roles = "1,3")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ConquistaUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
