using e_com_RSEt_API.BLL;
using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Http;
using System.Net.Http;


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
            if (customerDetail == null) { return NotFound(); }
            // check the password is null and return badreq
            if (string.IsNullOrEmpty(customerDetail.Password)) { return BadRequest("Password is required"); }
            bool emailExists = _context.CustomerDetails.Any(x => x.Email == customerDetail.Email); // check the email already have or no
            if (emailExists) { return StatusCode((int)HttpStatusCode.AlreadyReported); };
            int emailConfirmCode = general.emailConfirmCode();
            var homeBLL = new Customer_BLL(_context);
            var dto = new CustomerDetail
            {
                FristName = customerDetail.FristName,
                LastName = customerDetail.LastName,
                Email = customerDetail.Email,
                EmailValidate = Convert.ToInt32(1),
                Statest = 1,
                CreateDate = DateTime.Now,
                Dob = customerDetail.Dob,
                Password = general.hashPassword(customerDetail.Password),
                ConfiremCode = emailConfirmCode
            };
            homeBLL.saveCustomer(dto);
            if (customerDetail != null && !string.IsNullOrEmpty(customerDetail.Email))
            {
                string Email = customerDetail.Email;
                string Subject = "Confirm Code";
                string body = $"<h4>Welcome to our website!</h4><p>Thank you for signing up with us.</p><p>Please use the following confirmation code to complete your registration:</p><h2>{emailConfirmCode}</h2>";
                general.EmailSend(Email, Subject, body);
            }
            return Ok("SaveCustomer");
        }

        [HttpPost]
        [Route("emailVerify")]
        public IActionResult customerEmailVerify(CustomerDetail customerDetail)
        {
            if (customerDetail == null) { return NotFound(); }
            var customer = _context.CustomerDetails.FirstOrDefault(x => x.Email == customerDetail.Email && x.ConfiremCode == customerDetail.ConfiremCode);
            if (customer != null)
            {
                //Update the database customer validate the email address 
                customer.EmailValidate = 1;
                _context.SaveChanges();
                return Ok("sucess");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("customer-counts")]
        public IActionResult GetCustomerCounts()
        {
            var allCustomerCount = _context.CustomerDetails.Count();
            var activeCustomerCount = _context.CustomerDetails.Count(x => x.LogInOut == 1);
            var thiMonthJoinCustomerCount = _context.CustomerDetails.Count(x => x.CreateDate.Year == DateTime.Today.Year && x.CreateDate.Month == DateTime.Today.Month);
            var result = new
            {
                AllCustomer = allCustomerCount,
                ActiveCustomer = activeCustomerCount,
                ThisMonthJoinCustomer = thiMonthJoinCustomerCount,
            };
            return Ok(result);
        }

        [HttpGet]
        [Route("customerDetails")]
        public IActionResult customerDetails()
        {
            var customerDetail = _context.CustomerDetails.Select(x => new
            {
                UserId = x.UserId,
                FristName = x.FristName,
                Email = x.Email,
                LogInOut = x.LogInOut
            }).Take(100).ToList();
            return Ok(customerDetail);

            //int pageSize = 10;
            //var customerDetail = _context.CustomerDetails
            //.OrderByDescending(x => x.UserId)
            //    .Skip((page - 1) * pageSize)
            //    .Take(pageSize)
            //    .Select(x => new
            //    {
            //        UserId = x.UserId,
            //        FirstName = x.FristName,
            //        Email = x.Email,
            //        LogInOut = x.LogInOut
            //    }).ToList();

            //return Ok(customerDetail);
        }

    }
}
