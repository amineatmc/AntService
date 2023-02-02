using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        IPaymentTypeService _paymentTypeService;
        public PaymentTypeController(IPaymentTypeService paymentTypeService)
        {
            _paymentTypeService = paymentTypeService;
        }

        [HttpPost("[action]")]
        public IActionResult AddReq(PaymentType entity)
        {
            var paymentType = _paymentTypeService.Add(entity);
            if (!paymentType.Result.Success)
            {
                return BadRequest();
            }
            return Ok(entity);
        }

        [HttpGet("[action]")]
        public IActionResult GetReq(int id)
        {
            var entity = _paymentTypeService.GetbyId(id);
            if (!entity.Success)
            {
                return BadRequest();
            }
            return Ok(entity);
        }
    }
}
