using e_com_RSEt_API.BLL;
using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace e_com_RSEt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private readonly E_COM_WEBContext _context;
        private readonly IConfiguration _configuration;

        public productController(E_COM_WEBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("setAntivirus")]
        public IActionResult saveAntivirus(AntivirusGard antivirusGard)
        {
            if (antivirusGard == null)
            {
                return Ok("Error");
            }
            else
            {
                var homeBLL = new HomeBLL(_context);
                AntivirusGard antivirus = new AntivirusGard();
                antivirus.AntivirusName = antivirusGard.AntivirusName;
                antivirus.Price = antivirusGard.Price;
                homeBLL.saveAntivirusGard(antivirus);
                return Ok("Save Success");
            }
        }

        [HttpPost]
        [Route("save-hard-drive")]
        public IActionResult addNewHardDrive(CumputerHard hardDrive)
        {
            if (hardDrive == null)
            {
                return Ok("Error");
            }
            else
            {
                var homeBLL = new HomeBLL(_context);
                CumputerHard dto = new CumputerHard();
                dto.HardName = hardDrive.HardName;
                dto.Capacity = hardDrive.Capacity;
                dto.Type = hardDrive.Type;
                dto.Price = hardDrive.Price;
                homeBLL.saveNewHardDrive(dto);
                return Ok("Success add");
            }
        }

        [HttpPost]
        [Route("saveNewProcessor")]
        public IActionResult addNewProcessor(CumputerProcessor processorTyp)
        {
            if (processorTyp == null)
            {
                return Ok("Error");
            }
            else
            {
                var homeBLL = new HomeBLL(_context);
                CumputerProcessor dto = new CumputerProcessor();
                dto.ProcessorName = processorTyp.ProcessorName;
                dto.Capacity = processorTyp.Capacity;
                dto.PriceDouble = processorTyp.PriceDouble;
                homeBLL.saveProcessor(dto);
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
                return Ok("Error");
            }
            else
            {
                var homeBLL = new HomeBLL(_context);
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
                homeBLL.saveNewProduct(dto);
                return Ok("success");
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
                var homeBLL = new HomeBLL(_context);
                CumputerRam dto = new CumputerRam();
                dto.RamName = cumputerRam.RamName;
                dto.Capacity = cumputerRam.Capacity;
                dto.Price = cumputerRam.Price;
                homeBLL.addNewRam(dto);
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
                var homeBLL = new HomeBLL(_context);
                CumputerVga dto = new CumputerVga();
                dto.VgaName = cumputerVga.VgaName;
                dto.Capacity = cumputerVga.Capacity;
                dto.Price = cumputerVga?.Price;
                homeBLL.addNewVga(dto);
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
                var homeBLL = new HomeBLL(_context);
                LaptopDesktopView dto = new LaptopDesktopView();
                dto.Manufacture = laptopDesktopView.Manufacture;
                dto.Model = laptopDesktopView.Model;
                dto.Year = laptopDesktopView.Year;
                dto.LD = laptopDesktopView.LD;
                dto.Price = laptopDesktopView.Price;
                dto.ImagePath = laptopDesktopView.ImagePath;
                homeBLL.addNewLaptopOrDesktop(dto);
                return Ok("Success");
            }
        }
        /*add new computer series*/
        [HttpPost]
        [Route("addnewcpmseries")]
        public IActionResult addNewComputerSeries(ComSeries comSeries)
        {
            if (comSeries == null)
            {

                return NotFound();
            }
            else
            {
                var homeBLL = new HomeBLL(_context);
                ComSeries dto = new ComSeries();
                dto.SeriesName = comSeries.SeriesName;
                dto.MfId = comSeries.MfId;
                dto.ComputerTypeId = comSeries.ComputerTypeId;
                homeBLL.addnewComputerSeries(dto);
                return Ok("Success");
            }
        }
        /*add new computer series*/
        [HttpPost]
        [Route("newModel")]
        public IActionResult addNewModel(ComModel comModel)
        {
            if (comModel == null)
            {

                return NotFound();
            }
            else
            {
                var homeBLL = new HomeBLL(_context);
                ComModel dto = new ComModel();
                dto.ModelName = comModel.ModelName;
                dto.SeriesId = comModel.SeriesId;
                homeBLL.addnewModel(dto);
                return Ok("Success");
            }
        }
        [HttpGet]
        [Route("ComputerManufacturers")]
        public IActionResult GetCustomers()
        {
            try
            {
                var ComputerManufacturers = _context.ComputerManufacturers.ToList();
                return Ok(ComputerManufacturers);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving computer manufacturers. Please try again later.");
            }
        }
        [HttpGet]
        [Route("laptopOrDesktop")]
        public IActionResult laptopOrDesktopType()
        {
            try
            {
                var ComputerType = _context.ComputerTypes.ToList();
                return Ok(ComputerType);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
            }
        }
        [HttpGet]
        [Route("comSeries")]
        public IActionResult comSeries()
        {
            try
            {
                var comSeries = _context.ComSeries.ToList();
                return Ok(comSeries);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
            }
        }
        [HttpGet]
        [Route("comModels")]
        public IActionResult comModels()
        {
            try
            {
                var comModels = _context.ComModels.ToList();
                return Ok(comModels);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
            }
        }
        [HttpGet]
        [Route("getComputerDetails")]
        public IActionResult computerDetails()
        {
            try
            {
                seleComputerList dto = new seleComputerList();
                dto = HomeBLL.computerDetails();
                return Ok(dto.saleComputerDTOs);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
            }
        }
        [HttpPost]
        [Route("oderByModels")]
        public IActionResult oderByModels(ComModel model)
        {
            int ModelId = model.ModelId;
            try
            {
                seleComputerList dto = new seleComputerList();
                dto = HomeBLL.oderByModels(ModelId);
                return Ok(dto.saleComputerDTOs);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
            }
        }
        [HttpPost]
        [Route("oderBySeries")]
        public IActionResult oderBySeries(ComSeries comSeries)
        {
            int ModelId = comSeries.SeriesId;
            try
            {
                seleComputerList dto = new seleComputerList();
                dto = HomeBLL.oderBySeries(ModelId);
                return Ok(dto.saleComputerDTOs);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving computer Series. Please try again later.");
            }
        }


        [HttpPost]
        [Route("oderByComputerType")]
        public IActionResult oderByComputerType(ComputerType model)
        {
            int ModelId = model.ComputerTypeId;
            try
            {
                seleComputerList dto = new seleComputerList();
                dto = HomeBLL.oderByComputerType(ModelId);
                return Ok(dto.saleComputerDTOs);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
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

        [HttpGet]
        [Route("getProcessor")]
        public IActionResult getComputerProcessor()
        {
            try
            {
                var comProcessor = _context.CumputerProcessors.ToList();
                return Ok(comProcessor);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
            }
        }

        [HttpGet]
        [Route("getRam")]
        public IActionResult getComputerRam()
        {
            try
            {
                var comRam = _context.CumputerRams.ToList();
                return Ok(comRam);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
            }
        }

        [HttpGet]
        [Route("getVga")]
        public IActionResult getVga()
        {
            try
            {
                var comVga = _context.CumputerVgas.ToList();
                return Ok(comVga);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
            }
        }

        [HttpGet]
        [Route("getOS")]
        public async Task<ActionResult<List<ComputerO>>> GetComputerOs()
        {
            try
            {   
                var os = await _context.ComputerOs.ToListAsync();
                return Ok(os);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
            }
        }

        [HttpGet]
        [Route("getAntivirus")]
        public async Task<ActionResult<List<AntivirusGard>>> getAntivirus()
        {
            try
            {
                var os = await _context.AntivirusGards.ToListAsync();
                return Ok(os);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
            }
        }

        [HttpGet]
        [Route("getShipingMethod")]
        public async Task<ActionResult<List<ShipingMethod>>> getShipingMethod()
        {
            try
            {
                var shipingMethod = await _context.ShipingMethods.ToListAsync();
                return Ok(shipingMethod);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
            }
        }



    }
}
