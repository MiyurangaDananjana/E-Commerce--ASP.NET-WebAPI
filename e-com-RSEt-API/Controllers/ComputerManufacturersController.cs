using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using e_com_RSEt_API.Models;
using AutoMapper;
using Microsoft.VisualBasic;
using e_com_RSEt_API.BLL;

namespace e_com_RSEt_API.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerManufacturersController : Controller
    {
        private readonly E_COM_WEBContext _dbContext;

        public ComputerManufacturersController(E_COM_WEBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        [Route("ComputerManufacturers")]
        public IActionResult GetCustomers()
        {
            try
            {
                var ComputerManufacturers = _dbContext.ComputerManufacturers.ToList();
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
                var ComputerType = _dbContext.ComputerTypes.ToList();
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
                var comSeries = _dbContext.ComSeries.ToList();
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
                var comModels = _dbContext.ComModels.ToList();
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
        [Route("oderByModel")]
        public IActionResult oderByModel(ComModel model)
        {
            int ModelId = model.ModelId;
            try
            {
                seleComputerList dto = new seleComputerList();
                dto = HomeBLL.oderByModel(ModelId);
                return Ok(dto.saleComputerDTOs);
            }
            catch (Exception)
            {

                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
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
                var comProcessor = _dbContext.CumputerProcessors.ToList();
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
                var comRam = _dbContext.CumputerRams.ToList();
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
                var comVga = _dbContext.CumputerVgas.ToList();
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
                var os = await _dbContext.ComputerOs.ToListAsync();
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
                var os = await _dbContext.AntivirusGards.ToListAsync();
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
                var shipingMethod = await _dbContext.ShipingMethods.ToListAsync();
                return Ok(shipingMethod);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while retrieving computer type. Please try again later.");
            }
        }

      
    }
}
  