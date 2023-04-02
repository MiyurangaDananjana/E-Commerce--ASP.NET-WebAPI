using e_com_RSEt_API.BLL;
using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace e_com_RSEt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {

        private readonly M_SHOP_DBContext _context;
        private readonly IConfiguration _configuration;

        public userController(M_SHOP_DBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /*Admin details insert*/
        [HttpPost]
        [Route("saveAdminUser")]
        public IActionResult addNewAdminUser(AdminLogin adminLogin)
        {
            if (adminLogin == null)
            {
                return Ok("Error");
            }
            else
            {
                var newUser = new User_BLL(_context);
                AdminLogin dto = new AdminLogin();
                dto.FullName = adminLogin.FullName;
                dto.PhoneNumber = adminLogin.PhoneNumber;
                dto.Dob = adminLogin.Dob;
                dto.UserName = adminLogin.UserName;
                dto.Password = adminLogin.Password;
                newUser.addNewAdmin(dto);
                return Ok("success");
            }
        }


        /*Admin login check*/
        [HttpPost]
        [Route("adminLogin")]
        public IActionResult chackAdminLogin(AdminLogin adminLogin)
        {
            if (adminLogin == null)
            {
                return Ok("Error");
            }
            else
            {
                M_SHOP_DBContext db = new M_SHOP_DBContext();
                var checkAdmin = db.AdminLogins.Where(x => x.UserName == adminLogin.UserName && x.Password == adminLogin.Password).FirstOrDefault();
                if (checkAdmin != null)
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Error");
                }
            }
        }


    }
}
