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
    public class CursosController : ControllerBase
    {
        private ICursoRepository _CursoRepository { get; set; }

        public CursosController()
        {
            _CursoRepository = new CursoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_CursoRepository.Listar());
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
                return Ok(_CursoRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("institution/{id}")]
        public IActionResult GetByIdInstitution(int id)
        {
            try
            {
                return Ok(_CursoRepository.BuscarPorIdInstituicao(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // Role = 2 para Prof 
        [Authorize(Roles = "2")]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post([FromForm] Curso novoCurso)
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

                            novoCurso.Imagem = fileName.ToString();
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

                _CursoRepository.Cadastrar(novoCurso);

                return StatusCode(201);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // Role = 2 para Prof 
        [Authorize(Roles = "2")]
        [HttpPut("{id}"), DisableRequestSizeLimit]
        public IActionResult Put([FromForm] int id, Curso cursoAtualizado)
        {
            try
            {
                Curso cursoBuscado = _CursoRepository.BuscarPorId(id);

                if (Request.Form.Files["Imagem"] != null)
                {
                    var file = Request.Form.Files[0];
                    var folderName = Path.Combine("Resources", "Images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        var fullPath = Path.Combine(pathToSave, fileName);
                        var dbPath = Path.Combine(folderName, fileName);
                        if (fileName != cursoBuscado.Imagem)
                        {
                            string extensao = fileName + "-extensao/Ok";

                            if (extensao.Contains(".jpg-extensao/Ok") || extensao.Contains(".png-extensao/Ok") || extensao.Contains(".svg-extensao/Ok"))
                            {
                                var fullPathAnterior = Path.Combine(pathToSave, cursoBuscado.Imagem);
                                System.IO.File.Delete(fullPathAnterior.ToString());
                                using (var stream = new FileStream(fullPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                }

                                cursoAtualizado.Imagem = fileName.ToString();
                            }
                            else
                            {
                                return BadRequest("Insira uma imagem .jpg, .png ou .svg");
                            }
                        }
                    }
                }

                _CursoRepository.Atualizar(id, cursoAtualizado);

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
                Curso cursoBuscado = _CursoRepository.BuscarPorId(id);

                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                var fullPathAnterior = Path.Combine(pathToSave, cursoBuscado.Imagem);
                System.IO.File.Delete(fullPathAnterior.ToString());

                _CursoRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
