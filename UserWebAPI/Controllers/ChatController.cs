using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace UserWebAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        IChatService _chatService;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("[action]")]
        public IActionResult AddReq(Chat chat)
        {
            var result = _chatService.Add(chat);
            if (result.Result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        public IActionResult GetReqId(string id)
        {
            var result = _chatService.GetByRequestId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
