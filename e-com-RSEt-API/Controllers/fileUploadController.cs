using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_com_RSEt_API.Controllers
{
    //admin can uplod png and jpg imeges

    [Route("api/[controller]")]
    [ApiController]
    public class fileUploadController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        public fileUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        /*Image Upload*/
        [HttpPost]
        [Route("computer-image-upload")]
        public async Task<string> Post([FromForm] imageUpload imageUpload)
        {
            try
            {
                if (imageUpload.files.Length > 0)
                {
                   

                    string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + imageUpload.files.FileName))
                    {
                        imageUpload.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Upload Done";
                    }
                }
                else
                {
                    return "fales";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        
        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetImage([FromRoute] string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var filePath = path + fileName + ".png";
            var filePathjpg = path + fileName + ".jpg";
            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, "image/png");
            }
            else if (System.IO.File.Exists(filePathjpg))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePathjpg);
                return File(b, "image/jpg");
            }
            return null;
        }

    }
}
