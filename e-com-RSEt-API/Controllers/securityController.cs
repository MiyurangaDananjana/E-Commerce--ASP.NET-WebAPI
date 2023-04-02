using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_com_RSEt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class securityController : ControllerBase
    {
        private readonly M_SHOP_DBContext _context;
        private readonly IConfiguration _configuration;

        public securityController(M_SHOP_DBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public enum loginStates
        {
            loggedOut = 0,
            loggedIn = 1,
        }

        [HttpPost("authenticate")]
        public async Task<ActionResult<string>> Authenticate(CustomerDetail customerDetail)
        {
            if (customerDetail == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(customerDetail.Password))
            {
                return BadRequest("Password is required");
            }
            else
            {
                var customerCheck = await _context.CustomerDetails.FirstOrDefaultAsync(x => x.Email == customerDetail.Email && x.Password == general.hashPassword(customerDetail.Password));
                if (customerCheck == null)
                {
                    return StatusCode(404, "User Not Found");
                }
                // Generate JWT token
                var token = new JWTService(_configuration).GenerateToken(
                    customerCheck.UserId.ToString(),
                    customerCheck.FristName ?? ""
                );
                // Update the record
                customerCheck.LogInOut = (int)loginStates.loggedIn;
                customerCheck.LastLoginTime = DateTime.Now;
                _context.SaveChanges();

                //if (customerDetail != null && !string.IsNullOrEmpty(customerDetail.Email))
                //{
                //    string Email = customerDetail.Email;
                //    general.EmailSend(Email, "Login the M-SHOP", "Thanaq");
                //}


                return Ok(token);
            }

        }

    }
}
