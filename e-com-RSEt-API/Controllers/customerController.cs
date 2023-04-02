using e_com_RSEt_API.BLL;
using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_com_RSEt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class customerController : ControllerBase
    {
        private readonly M_SHOP_DBContext _context;
        private readonly IConfiguration _configuration;

        public customerController(M_SHOP_DBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("getUserAddress/{id}")]

        public IActionResult getUserAddress(int id)
        {
            try
            {
                var addresses = _context.CustomerAddressTbs.Where(a => a.CustomerCode == id).ToList();

                if (addresses.Count == 0)
                {
                    return NotFound();
                }

                return Ok(addresses);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving the address. Please try again later.");
            }
        }

        /*Add New Address*/
        [HttpPost]
        [Route("SetAddress")]
        public IActionResult saveCustomerAddress(CustomerAddressTb customerAddressTb)
        {
            if (customerAddressTb.CustomerCode == null)
            {
                return Ok("Error");
            }
            else
            {
                var homeBLL = new Customer_BLL(_context);
                CustomerAddressTb dto = new CustomerAddressTb();
                dto.CustomerCode = customerAddressTb.CustomerCode;
                dto.AddressLine1 = customerAddressTb.AddressLine1;
                dto.AddressLine2 = customerAddressTb.AddressLine2;
                dto.PostalCode = customerAddressTb.PostalCode;
                dto.City = customerAddressTb.City;
                homeBLL.saveCustomerAddress(dto);
                return Ok("Save Address");
            }
        }

        //save customer details to CUSTOMER_DETIL Tb
        [HttpPost]
        [Route("create-customer")]
        public IActionResult saveCustomerDetails(CustomerDetail customerDetail)
        {
            if (customerDetail == null)
            {
                return NotFound();
            }

            // check the password is null and return badreq
            if(string.IsNullOrEmpty(customerDetail.Password))
            {
                return BadRequest("Password is required");
            }
            else
            {
                var homeBLL = new Customer_BLL(_context);
                CustomerDetail dto = new CustomerDetail();
                dto.FristName = customerDetail.FristName;
                dto.LastName = customerDetail.LastName;
                dto.Email = customerDetail.Email;
                dto.EmailValidate = Convert.ToInt32(1);
                // dto.Gender= customerDetail.Gender;
                dto.Statest = 1;
                dto.CreateDate = DateTime.Now;
                dto.Dob = customerDetail.Dob;
                dto.Password = general.hashPassword(customerDetail.Password);
                homeBLL.saveCustomer(dto);
                return Ok("SaveCustomer");
            }
        }


    }
}
