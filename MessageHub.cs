using Microsoft.AspNetCore.SignalR;

namespace SignalRPrototype;

//TODO: refactor to strongly typed hub
public class MessageHub : Hub
{
    public async Task MessageAll(Message message)
        => await Clients.All.SendAsync("MessageReceived", message);
}
