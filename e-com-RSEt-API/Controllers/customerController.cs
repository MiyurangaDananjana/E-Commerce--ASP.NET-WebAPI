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
            if (emailExists)
            {
                string errorMessage = $"Email address '{customerDetail.Email}' already exists.";
                return StatusCode(StatusCodes.Status409Conflict, errorMessage); // return a 409 status code and a detailed error message
            };
            int emailConfirmCode = general.emailConfirmCode();
            var homeBLL = new Customer_BLL(_context);
            var dto = new CustomerDetail
            {
                FristName = customerDetail.FristName,
                LastName = customerDetail.LastName,
                Email = customerDetail.Email,
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

        [HttpPost]
        [Route("customerEmails")]
        public IActionResult CustomerEmails(CustomerEmail customerEmail)
        {
            if (customerEmail == null) { return NotFound(); }
            var Customer_BLL = new Customer_BLL(_context);
            var cusEmail = new CustomerEmail
            {
                Name = customerEmail.Name,
                Email = customerEmail.Email,
                Subject = customerEmail.Subject,
                Message = customerEmail.Message,
                Statest = 1 //1 one is non readed emails

            };
            Customer_BLL.insertEmail(cusEmail);
            return Ok("SeccessInsert");
        }

        [HttpGet("customer-profile/{userId}")]
        public IActionResult getCustomerProfile(int userId)
        {
            var profileData = _context.CustomerDetails.SingleOrDefault(x => x.UserId == userId);

            if (profileData == null) { return NotFound(userId); }

            var customerProfile = new CustomerProfile
            {
                userId = profileData?.UserId,
                FirstName = profileData?.FristName,
                LastName = profileData?.LastName,
                EmailAddress = profileData?.Email
            };
            return Ok(customerProfile);
        }

        [HttpPost]
        [Route("update-profile")]
        public IActionResult updateCustomerProfile(CustomerDetail customerDetail)
        {
            var customerProfile = _context.CustomerDetails.FirstOrDefault(x => x.UserId == customerDetail.UserId);

            if (customerProfile != null)
            {
                customerProfile.FristName = customerDetail.FristName;
                customerProfile.LastName = customerDetail.LastName;
                customerProfile.Email = customerDetail.Email;
                _context.SaveChanges();
                return Ok("sucess");
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        [Route("customerProfileUpdateVerify")]
        public IActionResult updateCustomerProfileUpdate(CustomerDetail customerDetail)
        {
            if(customerDetail == null) { NotFound(); }
            if (customerDetail != null && !string.IsNullOrEmpty(customerDetail.Email))
            {
                int emailConfirmCode = general.emailConfirmCode();
                string Email = customerDetail.Email;
                string Subject = "Confirm Code";
                string body = $"<h4>Welcome to our website!</h4><p>Thank you for signing up with us.</p><p>Please use the following confirmation code to complete your profile updates:</p><h2>{emailConfirmCode}</h2>";
                general.EmailSend(Email, Subject, body);

                var customer =_context.CustomerDetails.FirstOrDefault(x=>x.UserId == customerDetail.UserId);
                if (customer != null)
                {
                    customerDetail.ConfiremCode = emailConfirmCode;
                    _context.SaveChanges();
                }
                
            }
            return Ok("success");
        }
    }

}

