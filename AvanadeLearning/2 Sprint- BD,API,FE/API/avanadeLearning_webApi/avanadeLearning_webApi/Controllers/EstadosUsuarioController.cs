using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Domains;
using avanadeLearning_webApi.Interfaces;
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
    public class EstadosUsuarioController : ControllerBase
    {
        private IBaseRepository<EstadoUsuario> _EstadoUsuarioRepository { get; set; }

        public EstadosUsuarioController()
        {
            _EstadoUsuarioRepository = new EstadoUsuarioRepository();
        }

        // Role = 1 para Admin 
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_EstadoUsuarioRepository.Listar());
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
                return Ok(_EstadoUsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post(EstadoUsuario novoEstadoUsuario)
        {
            try
            {
                _EstadoUsuarioRepository.Cadastrar(novoEstadoUsuario);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, EstadoUsuario estadoUsuarioAtualizado)
        {
            try
            {
                _EstadoUsuarioRepository.Atualizar(id, estadoUsuarioAtualizado);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _EstadoUsuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
