using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
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
        private readonly M_SHOP_DBContext _context;
        private readonly IConfiguration _configuration;
        public fileUploadController(IWebHostEnvironment webHostEnvironment, M_SHOP_DBContext context, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _context = context;
            _configuration = configuration;
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

        [HttpPost]
        [Route("profile-customer")]
        public async Task<IActionResult> uploadProfilePhoto([FromForm] imageUpload imageUpload)
        {
            try
            {
                if (imageUpload.files.Length > 0)
                {
                    int customerId = imageUpload.userId; // Get the ID of the current customer (replace with your own code)
                    string path = _webHostEnvironment.WebRootPath + "\\profile-photos\\";
                    if (!Directory.Exists(path))
                    {
                        await Task.Run(() => Directory.CreateDirectory(path));
                    }
                    string randomNumberfileName = GenerateRandomNumber(6);
                    // Generate a unique file name for the uploaded file
                    string fileName = Path.GetFileNameWithoutExtension(imageUpload.files.FileName);
                    string extension = Path.GetExtension(imageUpload.files.FileName);
                    string uniqueFileName = randomNumberfileName + extension;
                    // Save the uploaded file with the unique file name
                    using (FileStream fileStream = System.IO.File.Create(Path.Combine(path, uniqueFileName)))
                    {
                        imageUpload.files.CopyTo(fileStream);
                        fileStream.Flush();
                        // Update the customer record in the database with the new file name
                     
                        var customer = _context.CustomerDetails.SingleOrDefault(c => c.UserId == customerId);
                        if (customer != null)
                        {
                            customer.ProfileImagePath = uniqueFileName;
                            _context.SaveChanges();
                        }
                        return Ok("Upload Done"); // HTTP 200 OK
                    }
                }
                else
                {
                    return BadRequest("Invalid request"); // HTTP 400 Bad Request
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error" + ex); // return JSON object with message property
            }
        }

        // Helper method to generate a random number with a specified number of digits
        private string GenerateRandomNumber(int numDigits)
        {
            Random random = new Random();
            int min = (int)Math.Pow(10, numDigits - 1);
            int max = (int)Math.Pow(10, numDigits) - 1;
            return random.Next(min, max).ToString("D6");
        }

        [HttpGet("{fileName}")]
        [Route("profile-customer/{fileName}")]
        public async Task<IActionResult> getprofilePhoto([FromRoute] string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\profile-photos\\";
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
    }
}
