﻿using AvanadeLearning.Interfaces;
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
    public class CategoriasQuestoesController : ControllerBase
    {
        private IBaseRepository<CategoriasQuestao> _CategoriasQuestaoRepository { get; set; }

        public CategoriasQuestoesController()
        {
            _CategoriasQuestaoRepository = new CategoriasQuestaoRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_CategoriasQuestaoRepository.Listar());
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
                return Ok(_CategoriasQuestaoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // Role = 2 para Prof 
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(CategoriasQuestao novaCategoriasQuestao)
        {
            try
            {
                _CategoriasQuestaoRepository.Cadastrar(novaCategoriasQuestao);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Role = 2 para Prof 
        [Authorize(Roles = "2")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, CategoriasQuestao CategoriasQuestaoAtualizada)
        {
            try
            {
                _CategoriasQuestaoRepository.Atualizar(id, CategoriasQuestaoAtualizada);

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
                _CategoriasQuestaoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
