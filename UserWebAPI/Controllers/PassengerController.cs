using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        IPassengerService _passengerService;
        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        [HttpGet("[action]")]
        public IActionResult GetPassenger(int id)
        {
            var passenger = _passengerService.GetById(id);
            if (passenger.Success)
            {
                return Ok(passenger);
            }
            return BadRequest();
        }
    }
}
