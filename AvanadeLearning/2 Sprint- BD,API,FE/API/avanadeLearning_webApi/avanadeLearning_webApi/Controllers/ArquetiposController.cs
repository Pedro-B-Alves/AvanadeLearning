using AvanadeLearning.Interfaces;
using avanadeLearning_webApi.Domains;
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
    public class ArquetiposController : ControllerBase
    {
        private IBaseRepository<Arquetipo> _ArquetipoRepository { get; set; }

        public ArquetiposController()
        {
            _ArquetipoRepository = new ArquetipoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ArquetipoRepository.Listar());
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
                return Ok(_ArquetipoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // Role = 1 para Admin 
        [Authorize(Roles = "1")]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post([FromForm] Arquetipo novoArquetipo)
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

                            novoArquetipo.Imagem = fileName.ToString();
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
                _ArquetipoRepository.Cadastrar(novoArquetipo);

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
        public IActionResult Put([FromForm] int id, Arquetipo arquetipoAtualizado)
        {
            try
            {
                Arquetipo arquetipoBuscado = _ArquetipoRepository.BuscarPorId(id);

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
                        if (fileName != arquetipoBuscado.Imagem)
                        {
                            string extensao = fileName + "-extensao/Ok";

                            if (extensao.Contains(".jpg-extensao/Ok") || extensao.Contains(".png-extensao/Ok") || extensao.Contains(".svg-extensao/Ok"))
                            {
                                var fullPathAnterior = Path.Combine(pathToSave, arquetipoBuscado.Imagem);
                                System.IO.File.Delete(fullPathAnterior.ToString());
                                using (var stream = new FileStream(fullPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                }

                                arquetipoAtualizado.Imagem = fileName.ToString();
                            }
                            else
                            {
                                return BadRequest("Insira uma imagem .jpg, .png ou .svg");
                            }
                        }
                    }
                }
                _ArquetipoRepository.Atualizar(id, arquetipoAtualizado);

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
                Arquetipo arquetipoBuscado = _ArquetipoRepository.BuscarPorId(id);

                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                var fullPathAnterior = Path.Combine(pathToSave, arquetipoBuscado.Imagem);
                System.IO.File.Delete(fullPathAnterior.ToString());

                _ArquetipoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
