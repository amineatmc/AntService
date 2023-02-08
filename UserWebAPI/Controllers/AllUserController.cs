using Business.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            AntTaksiContextDb db = new AntTaksiContextDb();

            List<UserALL> allUsers = db.UserALL.FromSqlRaw<UserALL>("select * from UserALL").ToList();          
                return Ok(allUsers);        
        }    
        [HttpGet("[action]")]
        public IActionResult GetAllUserById(int id)
        {
            AntTaksiContextDb db = new AntTaksiContextDb();

            List<UserALL> allUsers = db.UserALL.FromSqlRaw<UserALL>("select * from UserALL where AllUserID="+id).ToList();         
            return Ok(allUsers);            
        }

        [HttpGet("[action]")]
        public IActionResult GetPassengerById(int id)
        {
            AntTaksiContextDb db = new AntTaksiContextDb();

            List<UserALL> allUsers = db.UserALL.FromSqlRaw<UserALL>("select * from UserALL where PassengerID=" + id).ToList();
            return Ok(allUsers);
        }

        [HttpGet("[action]")]
        public IActionResult GetDriverById(int id)
        {
            AntTaksiContextDb db = new AntTaksiContextDb();

            List<UserALL> allUsers = db.UserALL.FromSqlRaw<UserALL>("select * from UserALL where DriverID=" + id).ToList();
            return Ok(allUsers);
        }

        [HttpGet("[action]")]
        public IActionResult GetStationById(int id)
        {
            AntTaksiContextDb db = new AntTaksiContextDb();

            List<UserALL> allUsers = db.UserALL.FromSqlRaw<UserALL>("select * from UserALL where SStationID=" + id).ToList();
            return Ok(allUsers);
        }
    }
}
