using AntalyaTaksiAccount.Models;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DriverController :ControllerBase
    {

        IDriverService _driverService;
        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _driverService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("[action]")]
        public IActionResult GetByTc(string tc)
        {
            var result = _driverService.GetByTc(tc);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _driverService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
