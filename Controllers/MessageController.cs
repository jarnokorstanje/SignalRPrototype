using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SignalRPrototype.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<MessageHub> _hubContext;

        public MessageController(IHubContext<MessageHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [Route("MessageAll")]
        [HttpPost(Name = "MessageAll")]
        public async Task<IActionResult> MessageAll(Message message)
        {
            await _hubContext.Clients.All.SendAsync("message", message);

            return Ok(message);
        }

        [Route("MessageUser")]
        [HttpPost(Name = "MessageUser")]
        public async Task<IActionResult> MessageUser(Message message)
        {
            DataAccess.SaveMessage(message);

            await _hubContext.Clients.Group($"user_{message.receiver}").SendAsync("message", message);

            return Ok(message);
        }
    }
}