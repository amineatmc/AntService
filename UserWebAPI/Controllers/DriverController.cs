﻿using AntalyaTaksiAccount.Models;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;


namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DriverController :ControllerBase
    {
        private readonly ILogger<DriverController> _logger;
        IDriverService _driverService;
        public DriverController(IDriverService driverService, ILogger<DriverController> logger)
        {
            _driverService = driverService;
            _logger = logger;
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var result = _driverService.GetById(id);
            if (result.Success)
            {
                _logger.LogInformation("test");
                return Ok(result);
            }
            return BadRequest();
        }


        [HttpGet("[action]")]
        public IActionResult GetByTc(string tc)
        {
            var result = _driverService.GetByTc(tc);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
      

        [HttpPut("[action]")]
        public IActionResult Update(DriverUpdateDto driverUpdateDto)
        {
            var result = _driverService.Update(driverUpdateDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("[action]")]
        public IActionResult GetDrivers()
        {
            var result = _driverService.GetAlls();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

    }
}
