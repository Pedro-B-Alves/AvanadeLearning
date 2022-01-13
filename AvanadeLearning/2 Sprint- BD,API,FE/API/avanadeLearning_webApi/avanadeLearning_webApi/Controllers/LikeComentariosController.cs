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
    public class LikeComentariosController : ControllerBase
    {
        private IBaseRepository<LikeComentario> _LikeComentarioRepository { get; set; }

        public LikeComentariosController()
        {
            _LikeComentarioRepository = new LikeComentarioRepository();
        }

        // Role = 1 para Admin 
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_LikeComentarioRepository.Listar());
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
                return Ok(_LikeComentarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // Role = 2 para Prof 
        // Role = 3 para Aluno 
        [Authorize(Roles = "2,3")]
        [HttpPost]
        public IActionResult Post(LikeComentario novoLikeComentario)
        {
            try
            {
                _LikeComentarioRepository.Cadastrar(novoLikeComentario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Role = 2 para Prof 
        // Role = 3 para Aluno 
        [Authorize(Roles = "2,3")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, LikeComentario LikeAtualizadoComentario)
        {
            try
            {
                _LikeComentarioRepository.Atualizar(id, LikeAtualizadoComentario);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Role = 1 para Admin 
        // Role = 2 para Prof 
        // Role = 3 para Aluno 
        [Authorize(Roles = "1,2,3")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _LikeComentarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
