using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace avanadeLearning_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivosController : ControllerBase
    {
        [HttpGet("images/{nome}")]
        public IActionResult SearchImages(string nome)
        {
            try
            {
                var folderName = Path.Combine("Resources", "Images");
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName, nome);

                string extensao = nome + "-extensao/Ok";

                if (extensao.Contains(".jpg-extensao/Ok"))
                {
                    return PhysicalFile(filePath, "image/jpg");
                }else if (extensao.Contains(".png-extensao/Ok"))
                {
                    return PhysicalFile(filePath, "image/png");
                }else if (extensao.Contains(".svg-extensao/Ok"))
                {
                    return PhysicalFile(filePath, "image/svg");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("files/{nome}")]
        public IActionResult SearchFiles(string nome)
        {
            try
            {
                var folderName = Path.Combine("Resources", "Files");
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName, nome);

                string extensao = nome + "-extensao/Ok";

                if (extensao.Contains(".rar-extensao/Ok"))
                {
                    return PhysicalFile(filePath, "file/rar");
                }else if (extensao.Contains(".zip-extensao/Ok"))
                {
                    return PhysicalFile(filePath, "file/zip");
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
