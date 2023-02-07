using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PassengerRequestController : ControllerBase
    {
        IPassengerRequestService _passengerRequestService;
        public PassengerRequestController(IPassengerRequestService passengerRequestService)
        {
            _passengerRequestService = passengerRequestService;
        }

        [HttpPost("[action]")]
        public IActionResult AddReq(PassengerRequest entity)
        {
            var history = _passengerRequestService.Add(entity);
            if (!history.Result.Success)
            {
                return BadRequest();
            }
            return Ok(entity);
        }

        [HttpGet("[action]")]
        public IActionResult GetReq(int id)
        {
            var history = _passengerRequestService.GetbyId(id);
            if (!history.Success)
            {
                return BadRequest();
            }
            return Ok(history);
        }

        [HttpGet("[action]")]
        public IActionResult GetByReqId(string id)
        {
            var history = _passengerRequestService.GetbyRequestId(id);
            if (!history.Success)
            {
                return BadRequest();
            }
            return Ok(history);
        }


        [HttpPost("[action]")]
        public IActionResult Update(PassengerRequestUpdateDto entity)
        {
            var data = _passengerRequestService.Update(entity);
            if (!data.Success)
            {
                return BadRequest();
            }
            return Ok(data);
        }
    }
}
