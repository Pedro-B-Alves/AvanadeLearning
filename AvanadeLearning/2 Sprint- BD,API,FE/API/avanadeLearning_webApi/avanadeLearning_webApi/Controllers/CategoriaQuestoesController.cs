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
    public class CategoriaQuestoesController : ControllerBase
    {
        private IBaseRepository<CategoriaQuestao> _CategoriaQuestaoRepository { get; set; }

        public CategoriaQuestoesController()
        {
            _CategoriaQuestaoRepository = new CategoriaQuestaoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_CategoriaQuestaoRepository.Listar());
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
                return Ok(_CategoriaQuestaoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // Role = 1 para Admin 
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(CategoriaQuestao novaCategoriaQuestao)
        {
            try
            {
                _CategoriaQuestaoRepository.Cadastrar(novaCategoriaQuestao);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Role = 1 para Admin 
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, CategoriaQuestao CategoriaQuestaoAtualizada)
        {
            try
            {
                _CategoriaQuestaoRepository.Atualizar(id, CategoriaQuestaoAtualizada);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Role = 1 para Admin 
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _CategoriaQuestaoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
