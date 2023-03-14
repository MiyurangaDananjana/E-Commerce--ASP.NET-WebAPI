using e_com_RSEt_API.BLL;
using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_com_RSEt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {

        private readonly E_COM_WEBContext dbContext;
        private readonly IConfiguration _config;

        public userController(E_COM_WEBContext context, IConfiguration config)
        {
            dbContext = context;
            _config = config;   
        }

        //save customer details to CUSTOMER_DETIL Tb
        [HttpPost]
        [Route("set-customer")]
        public IActionResult saveCustomerDetails(CustomerDetail customerDetail)
        {
            if (customerDetail == null)
            {
                return Ok("Error");
            }
            else
            {
                var homeBLL = new HomeBLL(dbContext);
                CustomerDetail dto = new CustomerDetail();
                dto.FristName = customerDetail.FristName;
                dto.LastName = customerDetail.LastName;
                dto.Email = customerDetail.Email;
                dto.EmailValidate = Convert.ToInt32(1);
                dto.Gender= customerDetail.Gender;
                dto.Dob = customerDetail.Dob;
                dto.Password= customerDetail.Password;
                dto.CustomerStatus = Convert.ToInt32(1);            
                homeBLL.saveCustomer(dto);
                return Ok("SaveCustomer");
            }

        }

        [HttpPost("authenticate")]
        public IActionResult Authentication(CustomerDetail customerDetail)
        {
            if(customerDetail == null)
            {
                return Ok("Not Found");
            }
            else
            {
                var customerCheck = dbContext.CustomerDetails.Where(x=>x.Email== customerDetail.Email && x.Password == customerDetail.Password).FirstOrDefault();
                if (customerCheck == null)
                {
                    return Ok("Error");
                }
                else
                {
                    return Ok(new JWTService(_config).GenerateToken(
                       customerCheck.CustomerId.ToString()
                       ));
                }
            }
        }




    }
}
