using e_com_RSEt_API.BLL;
using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_com_RSEt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class marketingAndSaleController : ControllerBase
    {

        private readonly E_COM_WEBContext _context;
        private readonly IConfiguration _configuration;

        public marketingAndSaleController(E_COM_WEBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("computerReq")]
        [Authorize]
        public IActionResult custometComReq(CopmOder copm)
        {
            if (copm == null)
            {
                return NotFound();
            }
            else
            {
                var homeBLL = new HomeBLL(_context);
                CopmOder dto = new CopmOder();
                dto.CusId = copm.CusId;
                dto.ProcessorId = copm.ProcessorId;
                dto.RamId = copm.RamId;
                dto.VgaId = copm.VgaId;
                dto.OsId = copm.OsId;
                dto.AntivirusGrdId = copm.AntivirusGrdId;
                dto.ShipingAddressId = copm.ShipingAddressId;
                dto.BullingAddressId = copm.BullingAddressId;
                dto.ShipingMethod = copm.ShipingMethod;
                dto.OderDate = DateTime.Today;
                dto.OderStatus = Convert.ToInt32(1);
                homeBLL.AddNewComputerReq(dto);
                return Ok("Success");
            }
        }

        [HttpPost]
        [Route("buyComputer")]
        public IActionResult buyComputer(NewComputer model)
        {
            int ModelId = model.ComId;
            try
            {
                seleComputerList dto = new seleComputerList();
                dto = HomeBLL.buyComputer(ModelId);
                return Ok(dto.saleComputerDTOs);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
            }
        }
    }
}
