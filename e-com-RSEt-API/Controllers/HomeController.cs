using e_com_RSEt_API.BLL;
using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_com_RSEt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : Controller
    {
       
        //save customer details to CUSTOMER_DETIL Tb
        [HttpPost]
        [Route("set-customer")]
        public IActionResult saveCustomerDetails(CustomerDetail customerDetail)
        {
            if (customerDetail == null)
            {
                return View("Error");
            }
            else
            {
                CustomerDetail dto = new CustomerDetail();
                dto.FristName = customerDetail.FristName;
                dto.LastName = customerDetail.LastName;
                dto.Email = customerDetail.Email;
                dto.PhoneNumber = customerDetail.PhoneNumber;
                dto.UserName = customerDetail.UserName;
                dto.Password = customerDetail.Password;
                dto.Statest = Convert.ToInt32(1);
                dto.CreateDate = DateTime.Now;
                HomeBLL.saveCustomer(dto);
                return Ok("SaveCustomer");
            }

        }

        /*Add New Address*/
        [HttpPost]
        [Route("SetAddress")]
        public IActionResult saveCustomerAddress(CustomerAddressTb customerAddressTb)
        {
            if (customerAddressTb.CustomerCode == null)
            {
                return View("Error");
            }
            else
            {
                CustomerAddressTb dto = new CustomerAddressTb();
                dto.CustomerCode = customerAddressTb.CustomerCode;
                dto.AddressLine1 = customerAddressTb.AddressLine1;
                dto.AddressLine2 = customerAddressTb.AddressLine2;
                dto.PostalCode = customerAddressTb.PostalCode;
                dto.City = customerAddressTb.City;
                HomeBLL.saveCustomerAddress(dto);
                return Ok("Save Address");
            }
        }

        /*Add Nee Antivirus Gard*/
        [HttpPost]
        [Route("setAntivirus")]
        public IActionResult saveAntivirus(AntivirusGard antivirusGard)
        {
            if (antivirusGard == null)
            {
                return View("Error");
            }
            else
            {
                AntivirusGard antivirus = new AntivirusGard();
                antivirus.AntivirusName = antivirusGard.AntivirusName;
                antivirus.Price = antivirusGard.Price;
                HomeBLL.saveAntivirusGard(antivirus);
                return Ok("Save Success");
            }
        }

        /*Add New HArd Drive*/
        [HttpPost]
        [Route("save-hard-drive")]
        public IActionResult addNewHardDrive(CumputerHard hardDrive)
        {
            if (hardDrive == null)
            {
                return View("Error");
            }
            else
            {
                CumputerHard dto = new CumputerHard();
                dto.HardName = hardDrive.HardName;
                dto.Capacity = hardDrive.Capacity;
                dto.Type = hardDrive.Type;
                dto.Price = hardDrive.Price;
                HomeBLL.saveNewHardDrive(dto);
                return Ok("Success add");
            }
        }

        /*Add new Processor*/
        [HttpPost]
        [Route("saveNewProcessor")]
        public IActionResult addNewProcessor(CumputerProcessor processorTyp)
        {
            if (processorTyp == null)
            {
                return View("Error");
            }
            else
            {
                CumputerProcessor dto = new CumputerProcessor();
                dto.ProcessorName = processorTyp.ProcessorName;
                dto.Capacity = processorTyp.Capacity;
                dto.PriceDouble = processorTyp.PriceDouble;
                HomeBLL.saveProcessor(dto);
                return Ok("success");
            }
        }

        /*Admin save new product*/
        [HttpPost]
        [Route("saveProductSpacification")]
        public IActionResult addNewProductSpacification(ProductSpacification productSpacification)
        {
            if (productSpacification == null)
            {
                return View("Error");
            }
            else
            {
                ProductSpacification dto = new ProductSpacification();
                dto.Name = productSpacification.Name;
                dto.ComouterType = productSpacification.ComouterType;
                dto.Processor = productSpacification.Processor;
                dto.Ram = productSpacification.Ram;
                dto.Hard = productSpacification.Hard;
                dto.Display = productSpacification.Display;
                dto.Wifi = productSpacification.Wifi;
                dto.Bt = productSpacification.Bt;
                dto.Antivirus = productSpacification.Antivirus;
                dto.Warranty = productSpacification.Warranty;
                dto.ImgePath = productSpacification.ImgePath;
                HomeBLL.saveNewProduct(dto);
                return Ok("success");
            }
        }

        /*Admin details insert*/
        [HttpPost]
        [Route("saveAdminUser")]
        public IActionResult addNewAdminUser(AdminLogin adminLogin)
        {
            if (adminLogin == null)
            {
                return View("Error");
            }
            else
            {
                AdminLogin dto = new AdminLogin();
                dto.FullName = adminLogin.FullName;
                dto.PhoneNumber = adminLogin.PhoneNumber;
                dto.Dob = adminLogin.Dob;
                dto.UserName = adminLogin.UserName;
                dto.Password = adminLogin.Password;
                HomeBLL.addNewAdmin(dto);
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
                return View("Error");
            }
            else
            {
                E_COM_WEBContext db = new E_COM_WEBContext();
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
        /*RAM INSERT*/
        [HttpPost]
        [Route("saveCusRam")]
        public IActionResult addNewRam(CumputerRam cumputerRam)
        {
            if (cumputerRam == null)
            {
                return BadRequest();
            }
            else
            {
                CumputerRam dto = new CumputerRam();
                dto.RamName = cumputerRam.RamName;
                dto.Capacity = cumputerRam.Capacity;
                dto.Price = cumputerRam.Price;
                HomeBLL.addNewRam(dto);
                return Ok("Success");
            }
        }
        /*VGA INSERT*/
        [HttpPost]
        [Route("addNewVGA")]
        public IActionResult addNewVga(CumputerVga cumputerVga)
        {
            if (cumputerVga == null)
            {
                return BadRequest();
            }
            else
            {
                CumputerVga dto = new CumputerVga();
                dto.VgaName = cumputerVga.VgaName;
                dto.Capacity = cumputerVga.Capacity;
                dto.Price = cumputerVga?.Price;
                HomeBLL.addNewVga(dto);
                return Ok("Success");
            }
        }
        /*add new laptop or desktop*/
        [HttpPost]
        [Route("newLapDesk")]
        public IActionResult addNewLaptopDesktop(LaptopDesktopView laptopDesktopView)
        {
            if (laptopDesktopView == null)
            {

                return NotFound();
            }
            else
            {
                LaptopDesktopView dto = new LaptopDesktopView();
                dto.Manufacture = laptopDesktopView.Manufacture;
                dto.Model = laptopDesktopView.Model;
                dto.Year = laptopDesktopView.Year;
                dto.LD = laptopDesktopView.LD;
                dto.Price = laptopDesktopView.Price;
                dto.ImagePath = laptopDesktopView.ImagePath;
                HomeBLL.addNewLaptopOrDesktop(dto);
                return Ok("Success");
            }
        }

     
    }
}
