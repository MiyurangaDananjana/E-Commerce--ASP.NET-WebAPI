using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_com_RSEt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class securityController : ControllerBase
    {
        private readonly E_COM_WEBContext _context;
        private readonly IConfiguration _configuration;

        public securityController(E_COM_WEBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("authenticate")]
        public IActionResult Authentication(CustomerDetail customerDetail)
        {
            if (customerDetail == null)
            {
                return NotFound();
            }
            else
            {
                var customerCheck = _context.CustomerDetails.Where(x => x.Email == customerDetail.Email && x.Password == customerDetail.Password).FirstOrDefault();
                if (customerCheck == null)
                {
                    return Ok("Error");
                }
                else
                {
                    return Ok(new JWTService(_configuration).GenerateToken(
                       customerCheck.CustomerId.ToString(),
                       customerCheck.FristName ?? ""
                       ));
                }
            }
        }

    }
}
