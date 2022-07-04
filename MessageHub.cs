using Microsoft.AspNetCore.SignalR;

namespace SignalRPrototype;

public class MessageHub : Hub
{
    public async Task MessageAll(Message message)
        => await Clients.All.SendAsync("message", message);

    public Task MessageUser(Message message)
    {
        return Clients.Group(message.receiver).SendAsync("message", message);
    }

    public async Task<Task> AddToGroup(string username)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, username);

        var missedMessages = DataAccess.GetMessagesByReceiver(username);

        return Clients.Group(username).SendAsync("missedMessages", missedMessages);
    }
    
    public void MessageResponse(Guid guid)
    {
        Console.WriteLine();
        Console.WriteLine("Response message received by server: " + guid);

        DataAccess.DeleteMessage(guid);
    }
}