using Business.Abstract;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

        private object typpe()
        {
            var token = _contextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            
            var userType = jwtSecurityToken.Claims.ToList()[3].Value;
            return userType;
        }


        [HttpGet("[action]")]
        public IActionResult GetAll() 
        {
            var token = _contextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var userType = jwtSecurityToken.Claims.ToList()[3].Value;
            
            if (userType == "2")
            {
                var result = _boundaryService.GetAll();
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            return BadRequest("yetki yok");
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _boundaryService.GetByStationId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
