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
    public class ConquistasController : ControllerBase
    {
        private IBaseRepository<Conquistum> _ConquistaRepository { get; set; }

        public ConquistasController()
        {
            _ConquistaRepository = new ConquistaRepository();
        }

        // Role = 1 para Admin 
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ConquistaRepository.Listar());
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
                return Ok(_ConquistaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        // Role = 2 para Prof 
        [Authorize(Roles = "2")]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post([FromForm] Conquistum novaConquista)
        {
            try
            {
                if (Request.Form.Files["Imagem"] == null)
                {
                    novaConquista.Imagem = "conquistaImg.svg";
                }
                else
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

                            novaConquista.Imagem = fileName.ToString();
                        }
                        else
                        {
                            return BadRequest("Insira uma imagem .jpg, .png ou .svg");
                        }
                    }
                }
                _ConquistaRepository.Cadastrar(novaConquista);

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
        public IActionResult Put([FromForm]int id, Conquistum conquistaAtualizada)
        {
            try
            {
                Conquistum conquistaBuscada = _ConquistaRepository.BuscarPorId(id);

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

                        if (fileName != conquistaBuscada.Imagem)
                        {
                            string extensao = fileName + "-extensao/Ok";

                            if (extensao.Contains(".jpg-extensao/Ok") || extensao.Contains(".png-extensao/Ok") || extensao.Contains(".svg-extensao/Ok"))
                            {
                                if (conquistaBuscada.Imagem != null && conquistaBuscada.Imagem != "conquistaImg.svg")
                                {
                                    var fullPathAnterior = Path.Combine(pathToSave, conquistaBuscada.Imagem);
                                    System.IO.File.Delete(fullPathAnterior.ToString());
                                }
                                using (var stream = new FileStream(fullPath, FileMode.Create))
                                {
                                    file.CopyTo(stream);
                                }
                                conquistaAtualizada.Imagem = fileName.ToString();

                            }
                        }
                    }
                
                }
                _ConquistaRepository.Atualizar(id, conquistaAtualizada);

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
                Conquistum conquistaBuscada = _ConquistaRepository.BuscarPorId(id);

                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (conquistaBuscada.Imagem != null && conquistaBuscada.Imagem != "conquistaImg.svg")
                {
                    var fullPathAnterior = Path.Combine(pathToSave, conquistaBuscada.Imagem);
                    System.IO.File.Delete(fullPathAnterior.ToString());
                }
                _ConquistaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
