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

        private static readonly string[] ExampleTexts = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet(Name = "GetMessage")]
        public Message Get()
        {
            return new Message(
                    ExampleTexts[Random.Shared.Next(ExampleTexts.Length)],
                    "User 1",
                    "User 2"
                );
        }

        [HttpPost(Name = "PostMessage")]
        public async Task<IActionResult> Post(Message message)
        {
            // Invoke SignalR client method
            await _hubContext.Clients.All.SendAsync("MessageReceived", message);

            return Ok(message);
        }
    }
}