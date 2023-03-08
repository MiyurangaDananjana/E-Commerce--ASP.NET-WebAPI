using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Runtime.InteropServices;

namespace e_com_RSEt_API.Controllers
{
    //admin can uplod png and jpg imeges

    [Route("api/[controller]")]
    [ApiController]
    public class fileUploadController : ControllerBase
    {
        [DisallowNull]
        private readonly IWebHostEnvironment _webHostEnvironment;
        public fileUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        /*Image Upload*/
        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetImage([FromRoute] string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var filePath = path + fileName;
            var filePathjpg = path + fileName;
            if (System.IO.File.Exists(filePath))
            {
                byte[] b = await System.IO.File.ReadAllBytesAsync(filePath);
                return File(b, "image/png");
            }
            else if (System.IO.File.Exists(filePathjpg))
            {
                byte[] b = await System.IO.File.ReadAllBytesAsync(filePathjpg);
                return File(b, "image/jpg");
            }
            // If the file is not found, return a 404 Not Found response
            return NotFound();
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> PostImage([FromForm] imageUpload imageUpload)
        {
            try
            {
                if (imageUpload.files.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        await Task.Run(() => Directory.CreateDirectory(path));
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + imageUpload.files.FileName))
                    {
                        imageUpload.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return Ok("Upload Done"); // HTTP 200 OK
                    }
                }
                else
                {
                    return BadRequest("Invalid request"); // HTTP 400 Bad Request
                }
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error"); // return JSON object with message property
            }
        }

    }
}
