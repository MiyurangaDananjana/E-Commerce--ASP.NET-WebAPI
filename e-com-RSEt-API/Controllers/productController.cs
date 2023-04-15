using e_com_RSEt_API.BLL;
using e_com_RSEt_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data.Entity;
using System.Reflection.Metadata;

namespace e_com_RSEt_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        private readonly M_SHOP_DBContext _context;
        private readonly IConfiguration _configuration;

        public productController(M_SHOP_DBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //[HttpPost]
        //[Route("setAntivirus")]
        //public IActionResult saveAntivirus(AntivirusGard antivirusGard)
        //{
        //    if (antivirusGard == null)
        //    {
        //        return Ok("Error");
        //    }
        //    else
        //    {
        //        var homeBLL = new HomeBLL(_context);
        //        AntivirusGard antivirus = new AntivirusGard();
        //        antivirus.AntivirusName = antivirusGard.AntivirusName;
        //        antivirus.Price = antivirusGard.Price;
        //        homeBLL.saveAntivirusGard(antivirus);
        //        return Ok("Save Success");
        //    }
        //}

        [HttpPost]
        [Route("save-hard-drive")]
        public IActionResult addNewHardDrive(ComputerHard hardDrive)
        {
            if (hardDrive == null)
            {
                return Ok("Error");
            }
            else
            {
                var homeBLL = new Product_BLL(_context);
                ComputerHard dto = new ComputerHard();
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
        public IActionResult addNewProcessor(ComputerProcessor processorTyp)
        {
            if (processorTyp == null)
            {
                return Ok("Error");
            }
            else
            {
                var homeBLL = new Product_BLL(_context);
                ComputerProcessor dto = new ComputerProcessor();
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
                var homeBLL = new Product_BLL(_context);
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
        public IActionResult addNewRam(ComputerRam cumputerRam)
        {
            if (cumputerRam == null)
            {
                return BadRequest();
            }
            else
            {
                var homeBLL = new Product_BLL(_context);
                ComputerRam dto = new ComputerRam();
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
        public IActionResult addNewVga(ComputerVga cumputerVga)
        {
            if (cumputerVga == null)
            {
                return BadRequest();
            }
            else
            {
                var homeBLL = new Product_BLL(_context);
                ComputerVga dto = new ComputerVga();
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
                var homeBLL = new Product_BLL(_context);
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
                var homeBLL = new Product_BLL(_context);
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
        public IActionResult addNewModel(ComputreModel comModel)
        {
            if (comModel == null)
            {

                return NotFound();
            }
            else
            {
                var homeBLL = new Product_BLL(_context);
                ComputreModel dto = new ComputreModel();
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
                var comModels = _context.ComputreModels.ToList();
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
                dto = Product_BLL.computerDetails();
                return Ok(dto.saleComputerDTOs);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
            }
        }
        [HttpPost]
        [Route("orderByModels")]
        public IActionResult oderByModels(ComputreModel model)
        {
            int ModelId = model.ModelId;
            try
            {
                seleComputerList dto = new seleComputerList();
                dto = Product_BLL.oderByModels(ModelId);
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
                dto = Product_BLL.oderBySeries(ModelId);
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
                dto = Product_BLL.oderByComputerType(ModelId);
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
                var comProcessor = _context.ComputerProcessors.ToList();
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
                var comRam = _context.ComputerRams.ToList();
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
                var comVga = _context.ComputerVgas.ToList();
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

        //[HttpGet]
        //[Route("getAntivirus")]
        //public async Task<ActionResult<List<AntivirusGard>>> getAntivirus()
        //{
        //    try
        //    {
        //        var os = await _context.AntivirusGards.ToListAsync();
        //        return Ok(os);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
        //    }
        //}

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

        [HttpPost]
        [Route("keyboard")]
        public IActionResult addNewKeyBord(Keyboard keyboard)
        {
            if (keyboard == null) { NotFound(); }
            int lastId = _context.Keyboards.OrderByDescending(x => x.KeyboardId).Select(x => x.KeyboardId).FirstOrDefault();
            //assign the new ID to the keyboard entity
            var newkeyBoard = new Keyboard
            {
                KeyboardId = lastId + 1,
                Brand = keyboard?.Brand,
                Model = keyboard?.Model,
                Connectivity = keyboard?.Connectivity,
                Compatibility = keyboard?.Compatibility,
                Price = keyboard?.Price,
                StockQuantity = keyboard?.StockQuantity,
            };
            _context.Keyboards.Add(newkeyBoard);
            _context.SaveChanges();
            return Ok("Success");
        }

        [HttpPost]
        [Route("mouse")]
        public IActionResult addNewMouse(Mouse mouse)
        {
            if (mouse == null) { NotFound(); }
            int mouseLastId = _context.Mouses.OrderByDescending(x => x.MouseId).Select(x => x.MouseId).FirstOrDefault();
            //assing the new ID to the mouse entity
            var mouseData = new Mouse
            {
                MouseId = mouseLastId + 1,
                Brand = mouse?.Brand,
                Model = mouse?.Model,
                Connectivity = mouse?.Connectivity,
                SensorType = mouse?.SensorType,
                Price = mouse?.Price,
                StockQuantity = mouse?.StockQuantity,
            };
            _context.Mouses.Add(mouseData);
            _context.SaveChanges();
            return Ok("sucess");
        }

        [HttpPut]
        [Route("keyboard/{id}")]
        public IActionResult UpdateKeyboard(int id, Keyboard keyboard)
        {
            if (keyboard == null)
            {
                return NotFound();
            }

            var existingKeyboard = _context.Keyboards.FirstOrDefault(x => x.KeyboardId == id);
            int? existingQuantity = existingKeyboard?.StockQuantity ?? 0;
            int? updateValue = existingQuantity + keyboard.StockQuantity;

            if (keyboard.StockQuantity == null) { NotFound("Stock Quantity is Null"); }


            if (existingKeyboard == null)
            {
                return NotFound();
            }

            existingKeyboard.Brand = keyboard?.Brand ?? existingKeyboard.Brand;
            existingKeyboard.Model = keyboard?.Model ?? existingKeyboard.Model;
            existingKeyboard.Connectivity = keyboard?.Connectivity ?? existingKeyboard.Connectivity;
            existingKeyboard.Compatibility = keyboard?.Compatibility ?? existingKeyboard.Compatibility;
            existingKeyboard.Price = keyboard?.Price ?? existingKeyboard.Price;
            existingKeyboard.StockQuantity = updateValue;

            _context.SaveChanges();

            return Ok("success");
        }

        [HttpPut]
        [Route("mouse/{id}")]
        public IActionResult UpdateMouse(int id, Mouse mouse)
        {
            if (mouse == null)
            {
                return NotFound();
            }

            var existingMouse = _context.Mouses.FirstOrDefault(x => x.MouseId == id);
            int? existingQuantity = existingMouse?.StockQuantity ?? 0;
            int? updateValue = existingQuantity + mouse.StockQuantity;

            if (mouse.StockQuantity == null) { NotFound("Stock Quantity is Null"); }


            if (existingMouse == null)
            {
                return NotFound();
            }

            existingMouse.Brand = mouse?.Brand ?? existingMouse.Brand;
            existingMouse.Model = mouse?.Model ?? existingMouse.Model;
            existingMouse.Connectivity = mouse?.Connectivity ?? existingMouse.Connectivity;
            existingMouse.SensorType = mouse?.SensorType ?? existingMouse.SensorType;
            existingMouse.Price = mouse?.Price ?? existingMouse.Price;
            existingMouse.StockQuantity = updateValue;

            _context.SaveChanges();

            return Ok("success");
        }


        [HttpGet]
        [Route("keyboards")]
        public IActionResult GetAllKeyboards()
        {
            var keyboards = _context.Keyboards.ToList();
            return Ok(keyboards);
        }

        [HttpGet]
        [Route("mouse")]
        public IActionResult getMouseData()
        {
            var mouseData = _context.Mouses.ToList();
            return Ok(mouseData);
        }

        [HttpDelete]
        [Route("keyboard/{id}")]
        public IActionResult DeleteKeyboard(int id)
        {
            var keyboard = _context.Keyboards.FirstOrDefault(x => x.KeyboardId == id);
            if (keyboard == null)
            {
                return NotFound();
            }

            _context.Keyboards.Remove(keyboard);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("mouse/{Id}")]
        public IActionResult deleteMouse(int Id)
        {
            var mouse = _context.Mouses.FirstOrDefault(x => x.MouseId == Id);
            if (mouse == null) { return NotFound(); }
            _context.Mouses.Remove(mouse);
            _context.SaveChanges();
            return Ok();
        }
    }
}
