using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController :ControllerBase
    {
        IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("[action]")]
        public IActionResult AddReq(Reservation reservation)
        {
            var result=_reservationService.Add(reservation);
            if (result.Result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _reservationService.GetbyId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetByPassengerId(int id)
        {
            var result = _reservationService.GetByPassengerId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetByDriverId(int id)
        {
            var result = _reservationService.GetByDriverId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetByStationId(int id)
        {
            var result = _reservationService.GetByStationId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        public IActionResult ReservationAssignment(ReservationAssignmentDto entity)
        {
            var result = _reservationService.ReservationAssignment(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
        // GetByStationIdActive

        [HttpGet("[action]")]
        public IActionResult GetByStationIdActive(int id)
        {
            var result = _reservationService.GetByStationIdActive(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetByDriverIdActive(int id)
        {
            var result = _reservationService.GetByDriverIdActive(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(int id)
        {
            var result = _reservationService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
