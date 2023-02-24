using Autofac.Core;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PassengerCancelTravelController : ControllerBase
    {
        IPassengerCancelTravelService _passengerCancelTravelService;
        public PassengerCancelTravelController(IPassengerCancelTravelService passengerCancelTravelService)
        {
            _passengerCancelTravelService= passengerCancelTravelService;
        }

        [HttpPost("[action]")]
        public IActionResult Add(PassengerCancelTravel passenger)
        {
            var result = _passengerCancelTravelService.Add(passenger);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetByDriverId(int id)
        {
            var result = _passengerCancelTravelService.GetByPassengerId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
