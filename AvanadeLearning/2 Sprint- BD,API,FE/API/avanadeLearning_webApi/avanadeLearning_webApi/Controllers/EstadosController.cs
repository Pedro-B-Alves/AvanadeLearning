using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Domains;
using avanadeLearning_webApi.Interfaces;
using avanadeLearning_webApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private IEstadoRepository _EstadoRepository { get; set; }

        public EstadosController()
        {
            _EstadoRepository = new EstadoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_EstadoRepository.Listar());
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
                return Ok(_EstadoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("country/{id}")]
        public IActionResult GetByIdCountry(int id)
        {
            try
            {
                return Ok(_EstadoRepository.BuscarPorIdPais(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // Role = 1 para Admin 
        [Authorize(Roles = "1")]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post([FromForm] Estado novoEstado)
        {
            try
            {
                if (Request.Form.Files["Imagem"] != null)
                {
                    var file = Request.Form.Files["Imagem"];
                    var folderName = Path.Combine("Resources", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);

                        string extensao = fileName + "-extensao/Ok";

                        if (extensao.Contains(".jpg-extensao/Ok") || extensao.Contains(".png-extensao/Ok") || extensao.Contains(".svg-extensao/Ok"))
                        {
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }

                            novoEstado.Imagem = fileName.ToString();
                        }
                        else
                        {
                            return BadRequest("Insira uma imagem .jpg, .png ou .svg");
                        }
                    }
                }
                else
                {
                    return BadRequest("Insira uma imagem");
                }
                _EstadoRepository.Cadastrar(novoEstado);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Role = 1 para Admin 
        [Authorize(Roles = "1")]
        [HttpPut("{id}"), DisableRequestSizeLimit]
        public IActionResult Put([FromForm] int id, Estado estadoAtualizado)
        {
            try
            {
                Estado estadoBuscado = _EstadoRepository.BuscarPorId(id);

                if (Request.Form.Files["Imagem"] != null)
                {
                    var file = Request.Form.Files["Imagem"];
                    var folderName = Path.Combine("Resources", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
                        if (fileName != estadoBuscado.Imagem)
                        {
                            string extensao = fileName + "-extensao/Ok";

                            if (extensao.Contains(".jpg-extensao/Ok") || extensao.Contains(".png-extensao/Ok") || extensao.Contains(".svg-extensao/Ok"))
                            {
                                var fullPathAnterior = Path.Combine(pathToSave, estadoBuscado.Imagem);
                                System.IO.File.Delete(fullPathAnterior.ToString());
                                using (var stream = new FileStream(fullPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                }

                                estadoAtualizado.Imagem = fileName.ToString();
                            }
                            else
                            {
                                return BadRequest("Insira uma imagem .jpg, .png ou .svg");
                            }
                        }
                    }
                }
                _EstadoRepository.Atualizar(id, estadoAtualizado);

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
                Estado estadoBuscado = _EstadoRepository.BuscarPorId(id);

                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                var fullPathAnterior = Path.Combine(pathToSave, estadoBuscado.Imagem);
                System.IO.File.Delete(fullPathAnterior.ToString());

                _EstadoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
