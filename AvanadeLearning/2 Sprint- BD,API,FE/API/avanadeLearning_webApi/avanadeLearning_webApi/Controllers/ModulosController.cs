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
    public class ModulosController : ControllerBase
    {
        private IBaseRepository<Modulo> _ModuloRepository { get; set; }
        private readonly IModuloRepository _moduloRepository;

        public ModulosController()
        {
            _ModuloRepository = new ModuloRepository();
            _moduloRepository = new ModuloRepository();
        }

        // Role = 1 para Admin 
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ModuloRepository.Listar());
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
                return Ok(_ModuloRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("modulo/{idCurso}")]
        public IActionResult GetByIdCurso(int idCurso)
        {
            try
            {
                return Ok(_moduloRepository.BuscarPorIdCurso(idCurso));
            }
            catch (Exception)
            {

                throw;
            }
        }

        // Role = 2 para Prof 
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Modulo novoModulo)
        {
            try
            {
                _ModuloRepository.Cadastrar(novoModulo);

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
        public IActionResult Put(int id, Modulo ModuloAtualizado)
        {
            try
            {
                _ModuloRepository.Atualizar(id, ModuloAtualizado);

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
                _ModuloRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
