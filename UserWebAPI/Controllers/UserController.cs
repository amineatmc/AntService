using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IAllUserService _userService;
        public UserController(IAllUserService userService)
        {
            _userService= userService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll() 
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }


      
    }
}
