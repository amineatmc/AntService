using Business.Abstract;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Entities.Concrete;
using Entities.Dtos;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoundaryController : ControllerBase
    {
        IBoundaryService _boundaryService;
        IHttpContextAccessor _contextAccessor;
        public BoundaryController(IBoundaryService boundaryService)
        {
            _boundaryService= boundaryService;
            _contextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }


        [HttpGet("[action]")]
        public IActionResult GetAll() 
        {
            //var token = _contextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

            //var handler = new JwtSecurityTokenHandler();
            //var jwtSecurityToken = handler.ReadJwtToken(token);
            //var userType = jwtSecurityToken.Claims.ToList()[3].Value;
            
            //if (userType == "2")
            //{
                var result = _boundaryService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest();
            //}
            //return BadRequest("yetki yok");
        }

        [HttpGet("[action]")]
        public IActionResult GetByStationId(int id)
        {
            var result = _boundaryService.GetByStationId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        public IActionResult Add(Boundary boundary)
        {
            var result = _boundaryService.Add(boundary);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpPut("[action]")]
        public IActionResult Update(BoundaryUpdateDto boundary)
        {
           
            var result = _boundaryService.Update(boundary);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("[action]")]
        public IActionResult Delete(int id)
        {

            var result = _boundaryService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
