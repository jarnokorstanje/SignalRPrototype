using Microsoft.AspNetCore.Mvc;

namespace SignalRPrototype.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet(Name = "GetMessage")]
        public Message Get()
        {
            return new Message
            {
                Body = Summaries[Random.Shared.Next(Summaries.Length)]
            };
        }

        [HttpPost(Name = "PostMessage")]
        public string Post(Message message)
        {
            // Invoke SignalR stuff here

            return $"Sending message: {message.Body}";
        }
    }
}