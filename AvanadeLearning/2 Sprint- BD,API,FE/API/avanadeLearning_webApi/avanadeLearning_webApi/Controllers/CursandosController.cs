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
    public class CursandosController : ControllerBase
    {
        private ICursandoRepository _CursandoRepository { get; set; }

        public CursandosController()
        {
            _CursandoRepository = new CursandoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_CursandoRepository.Listar());
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
                return Ok(_CursandoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [Authorize]
        [HttpGet("user/{id}")]
        public IActionResult GetByIdUser(int id)
        {
            try
            {
                return Ok(_CursandoRepository.BuscarPorIdUsuario(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // Role = 3 para Aluno 
        [Authorize(Roles = "3")]
        [HttpPost]
        public IActionResult Post(Cursando novoCursando)
        {
            try
            {
                _CursandoRepository.Cadastrar(novoCursando);

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
        public IActionResult Put(int id, Cursando CursandoAtualizado)
        {
            try
            {
                _CursandoRepository.Atualizar(id, CursandoAtualizado);

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
                _CursandoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
