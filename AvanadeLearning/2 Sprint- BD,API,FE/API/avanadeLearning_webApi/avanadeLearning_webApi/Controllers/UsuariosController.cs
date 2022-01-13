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
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _UsuarioRepository { get; set; }

        public UsuariosController()
        {
            _UsuarioRepository = new UsuarioRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_UsuarioRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("email/{email}")]
        public IActionResult GetByEmail(string email)
        {
            try
            {
                return Ok(_UsuarioRepository.BuscarPorEmail(email));
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
                return Ok(_UsuarioRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost, DisableRequestSizeLimit]
        public IActionResult Post([FromForm] Usuario novoUsuario)
        {
            try
            {
                if(Request.Form.Files["Imagem"] == null)
                {
                    novoUsuario.Imagem = "usuario.png";
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

                            novoUsuario.Imagem = fileName.ToString();
                        }
                        else
                        {
                            return BadRequest("Insira uma imagem .jpg, .png ou .svg");
                        }
                    }
                }
                if(Request.Form.Files["ImagemBackground"] == null)
                {
                    novoUsuario.ImagemBackground = "imgBackground.jpg";
                }
                else
                {
                    var file = Request.Form.Files["ImagemBackground"];
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

                            novoUsuario.ImagemBackground = fileName.ToString();
                        }
                        else
                        {
                            return BadRequest("Insira uma imagem .jpg, .png ou .svg");
                        }

                    }

                }

                if (novoUsuario.Empresa == null)
                {
                    novoUsuario.Empresa = "Empresa não informada";
                }

                if (novoUsuario.Cargo == null)
                {
                    novoUsuario.Cargo = "Cargo não informado";
                }

                if (novoUsuario.SobreMim == null)
                {
                    novoUsuario.SobreMim = "Eu sou o/a " + novoUsuario.Nome;
                }

                novoUsuario.Pontos = 0;
                novoUsuario.PontosSemanais = 0;

                novoUsuario.Senha = Criptografar(novoUsuario.Senha);

                if (novoUsuario.DataNascimento != null)
                {
                    if (!ValidarIdade(novoUsuario.DataNascimento.ToString()))
                    {
                        return BadRequest("Dados incorretos");
                    }
                }

                if (novoUsuario.Cpf != null)
                {
                    if (!ValidaCPF(novoUsuario.Cpf))
                        return BadRequest("Dados incorretos");
                }

                _UsuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        private string Criptografar(string senha)
        {
            return BCrypt.Net.BCrypt.HashPassword(senha);
        }

        private bool ValidaCPF(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf;

            string digito;

            int soma;

            int resto;

            cpf = cpf.Trim();

            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)

                return false;

            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf = tempCpf + digito;

            soma = 0;

            for (int i = 0; i < 10; i++)

                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);
        }

        private bool ValidarIdade(string data)
        {
            DateTime dataNascimento = Convert.ToDateTime(data);

            int anos = DateTime.Today.Year - dataNascimento.Year;

            if (dataNascimento.Month > DateTime.Today.Month || dataNascimento.Month == DateTime.Today.Month && dataNascimento.Day > DateTime.Today.Day)
                anos--;

            if(anos >= 16 && anos <= 100)
            {
                return true;
            }

            return false;
        }

        [Authorize]
        [HttpPut("{id}"), DisableRequestSizeLimit]
        public IActionResult Put([FromForm] int id, Usuario usuarioAtualizado)
        {
            try
            {
                Usuario usuarioBuscado = _UsuarioRepository.BuscarPorId(id);
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
                            if (usuarioBuscado.Imagem != null && usuarioBuscado.Imagem != "usuario.png")
                            {
                                var fullPathAnterior = Path.Combine(pathToSave, usuarioBuscado.Imagem);
                                System.IO.File.Delete(fullPathAnterior.ToString());
                            }
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }

                            usuarioAtualizado.Imagem = fileName.ToString();
                        }
                        else
                        {
                            return BadRequest("Insira uma imagem .jpg, .png ou .svg");
                        }

                        
                    }
                }
                
                if (Request.Form.Files["ImagemBackground"] != null)
                {
                    var file = Request.Form.Files["ImagemBackground"];
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
                            if (usuarioBuscado.ImagemBackground != null && usuarioBuscado.ImagemBackground != "imgBackground.jpg")
                            {
                                var fullPathAnterior = Path.Combine(pathToSave, usuarioBuscado.ImagemBackground);
                                System.IO.File.Delete(fullPathAnterior.ToString());
                            }
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                            }

                            usuarioAtualizado.ImagemBackground = fileName.ToString();
                        }
                        else
                        {
                            return BadRequest("Insira uma imagem .jpg, .png ou .svg");
                        }

                    }
                }
                

                if (usuarioAtualizado.Senha != null)
                {
                    usuarioAtualizado.Senha = Criptografar(usuarioAtualizado.Senha);
                }

                if (usuarioAtualizado.DataNascimento != null)
                {
                    if (!ValidarIdade(usuarioAtualizado.DataNascimento.ToString()))
                    {
                        return BadRequest("Dados incorretos");
                    }
                }

                if (usuarioAtualizado.Cpf != null)
                {
                    if (!ValidaCPF(usuarioAtualizado.Cpf))
                    {
                        return BadRequest("Dados incorretos");
                    }
                }

                _UsuarioRepository.Atualizar(id, usuarioAtualizado);

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
                Usuario usuarioBuscado = _UsuarioRepository.BuscarPorId(id);

                var folderName = Path.Combine("Resources", "Images");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (usuarioBuscado.Imagem != null && usuarioBuscado.Imagem != "usuario.png")
                {
                    var fullPathAnterior = Path.Combine(pathToSave, usuarioBuscado.Imagem);
                    System.IO.File.Delete(fullPathAnterior.ToString());
                }

                if (usuarioBuscado.ImagemBackground != null && usuarioBuscado.ImagemBackground != "imgBackground.jpg")
                {
                    var fullPathAnterior = Path.Combine(pathToSave, usuarioBuscado.ImagemBackground);
                    System.IO.File.Delete(fullPathAnterior.ToString());
                }

                _UsuarioRepository.Deletar(id);

                return StatusCode(204);
            }

            catch (Exception ex)

            {
                return BadRequest(ex);
            }

        }
    }
}
