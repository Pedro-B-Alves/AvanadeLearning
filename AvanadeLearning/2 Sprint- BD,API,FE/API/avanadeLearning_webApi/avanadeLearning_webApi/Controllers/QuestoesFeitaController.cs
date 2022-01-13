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
    public class QuestoesFeitaController : ControllerBase
    {
        private IBaseRepository<QuestaoFeitum> _QuestaoFeitaRepository { get; set; }

        public QuestoesFeitaController()
        {
            _QuestaoFeitaRepository = new QuestaoFeitaRepository();
        }

        // Role = 1 para Admin 
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_QuestaoFeitaRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // Role = 1 para Admin 
        // Role = 2 para Prof 
        // Role = 3 para Aluno 
        [Authorize(Roles = "2, 3")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_QuestaoFeitaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // Role = 3 para Aluno 
        [Authorize(Roles = "3")]
        [HttpPost]
        public IActionResult Post(QuestaoFeitum novaQuestaoFeita)
        {
            try
            {
                _QuestaoFeitaRepository.Cadastrar(novaQuestaoFeita);

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
        public IActionResult Put(int id, QuestaoFeitum QuestaoFeitaAtualizada)
        {
            try
            {
                _QuestaoFeitaRepository.Atualizar(id, QuestaoFeitaAtualizada);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Role = 3 para Aluno 
        [Authorize(Roles = "3")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _QuestaoFeitaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
