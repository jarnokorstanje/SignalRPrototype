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

        [Route("MessageUser")]
        [HttpPost(Name = "MessageUser")]
        public async Task<IActionResult> MessageUser(Message message)
        {
            MessageStorage.SaveMessage(message, new ConsoleTextWriter());

            await _hubContext.Clients.Group(message.receiver).SendAsync("message", message);

            return Ok(message);
        }
    }
}