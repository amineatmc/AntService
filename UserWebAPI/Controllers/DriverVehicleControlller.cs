using AntalyaTaksiAccount.Models;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DriverVehicleControlller : ControllerBase
    {
        IDriverVehicleService _driverVehicleService;
        public DriverVehicleControlller(IDriverVehicleService driverVehicleService)
        {
            _driverVehicleService = driverVehicleService;
        }


        [HttpPost("[action]")]
        public IActionResult AddReq(DriverVehicle entity)
        {
            var history = _driverVehicleService.Add(entity);
            if (!history.Result.Success)
            {
                return BadRequest();
            }
            return Ok(entity);
        }

    }
}
