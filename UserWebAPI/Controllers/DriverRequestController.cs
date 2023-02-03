﻿using Business.Abstract;
using Core.Utilities.Result.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UserWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverRequestController :ControllerBase
    {
        private readonly IDriverRequestService _driverRequestService;
        public DriverRequestController(IDriverRequestService driverRequestService)
        {
            _driverRequestService = driverRequestService;
        }

        [HttpPost("[action]")]
        public IActionResult AddReq(DriverRequest entity)
        {
            var history = _driverRequestService.Add(entity);
            if (!history.Result.Success)
            {
                return BadRequest();
            }
            return Ok(entity);
        }

        [HttpGet("[action]")]
        public IActionResult GetById(int id)
        {
            var history = _driverRequestService.GetbyId(id);
            if (!history.Success)
            {
                return BadRequest();
            }
            return Ok(history);
        }

        [HttpGet("[action]")]
        public IActionResult GetReqId(string id)
        {
            var history = _driverRequestService.GetbyRequestId(id);
            if (!history.Success)
            {
                return BadRequest();
            }
            return Ok(history);
        }
    }
}