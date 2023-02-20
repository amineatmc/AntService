using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelHistoryController : ControllerBase
    {
        ITravelHistoryService _travelHistoryService;
        IHttpContextAccessor _contextAccessor;
        IDriverDal _driverDal;
        IPassengerDal _passengerDal;
        public TravelHistoryController(ITravelHistoryService travelHistoryService, IHttpContextAccessor contextAccessor,IDriverDal driverDal,IPassengerDal passengerDal)
        {
            _travelHistoryService = travelHistoryService;
            _contextAccessor = contextAccessor;
            _driverDal = driverDal;
            _passengerDal = passengerDal;
        }

        [HttpPost("[action]")]
        public IActionResult Add(TravelHistory entity)
        {
            var history= _travelHistoryService.Add(entity);
            if (!history.Result.Success)
            {
                return BadRequest();
            }
            return Ok(entity);
        }

        [HttpGet("[action]")]
        public IActionResult GetByPassengerId(int id)
        {
            /*Station Yetkisi*/

            //var token = _contextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            //var handler = new JwtSecurityTokenHandler();
            //var jwtSecurityToken = handler.ReadJwtToken(token);
            //var userType = jwtSecurityToken.Claims.ToList()[3].Value;
            //var AllUserId = jwtSecurityToken.Claims.ToList()[1].Value;

            //if (userType=="3")
            //{
                var history = _travelHistoryService.GetByPassengerId(id);
                if (!history.Success)
                {
                    return BadRequest();
                }
                return Ok(history);
            }
            //return BadRequest();
       // }

        [HttpGet("[action]")]
        public IActionResult GetByDriverId(int id)
        {
            /*Station Yetkisi*/

           // var token = _contextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
           // var handler = new JwtSecurityTokenHandler();
           // var jwtSecurityToken = handler.ReadJwtToken(token);
           // var userType = jwtSecurityToken.Claims.ToList()[3].Value;
           //// var AllUserId = jwtSecurityToken.Claims.ToList()[1].Value;           
           // if (userType == "3")
           // {
                var history = _travelHistoryService.GetByDriverId(id);
                if (!history.Success)
                {
                    return BadRequest();
                }
                return Ok(history);
            //}
            //return BadRequest("Yetki Yok");
        }

        [HttpGet("[action]")]
        public IActionResult GetByTravelId(int id)
        {
            /*Station Yetkisi*/
            //var token = _contextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            //var handler = new JwtSecurityTokenHandler();
            //var jwtSecurityToken = handler.ReadJwtToken(token);
            //var userType = jwtSecurityToken.Claims.ToList()[3].Value;
            //if (userType == "3")
            //{
                var history = _travelHistoryService.GetbyId(id);
                if (!history.Success)
                {
                    return BadRequest();
                }
                return Ok(history);
            //}
            //return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult DriverTravel()
        {
            /*driver Yetkisi*/

            var token = _contextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var userType = jwtSecurityToken.Claims.ToList()[4].Value;
            var AllUserId = jwtSecurityToken.Claims.ToList()[1].Value;
            var driverId = _driverDal.Get(x => x.AllUserID == Convert.ToInt32(AllUserId));

            if (userType == "Driver")
            {
                var history = _travelHistoryService.DriverTravel(Convert.ToInt32(driverId.DriverID));
                if (!history.Success)
                {
                    return BadRequest();
                }
                return Ok(history);
            }
            return BadRequest("Yetki Yok");
        }

        [HttpGet("[action]")]
        public IActionResult PassengerTravel()
        {
            /*Passenger Yetkisi*/
            var token = _contextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var userType = jwtSecurityToken.Claims.ToList()[4].Value;
            var AllUserId = jwtSecurityToken.Claims.ToList()[1].Value;

            var passengerId = _passengerDal.Get(x => x.AllUserID == Convert.ToInt32(AllUserId));

            if (userType == "User")
            {
                var history = _travelHistoryService.PassengerTravel(Convert.ToInt32(passengerId.PassengerID));
                if (!history.Success)
                {
                    return BadRequest();
                }
                return Ok(history);
            }
            return BadRequest("Yetki Yok");
        }

        [HttpGet("[action]")]
        public IActionResult GetByRequestId(string id)
        {
            var result = _travelHistoryService.GetByRequestId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        public IActionResult Update(TravelHistoryUpdateDto entity)
        {
            var result= _travelHistoryService.Update(entity);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _travelHistoryService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetByStationId(int id)
        {
            var result = _travelHistoryService.GetByStationId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
