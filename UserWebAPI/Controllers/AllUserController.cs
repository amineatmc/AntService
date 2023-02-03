using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AllUserController:ControllerBase
    {
        IAllUserService _allUserService;
        public AllUserController(IAllUserService allUserService)
        {
            _allUserService = allUserService;
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result= _allUserService.GetbyId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
