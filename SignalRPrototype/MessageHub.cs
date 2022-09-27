using Microsoft.AspNetCore.SignalR;

namespace SignalRPrototype;

public class MessageHub : Hub
{
    public async void AddToGroup(string username)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, username);

        var missedMessages = MissedMessages.GetMessagesByReceiver(username);

        Clients.Group(username).SendAsync("missedMessages", missedMessages);
    }
    
    public void MessageResponse(Guid guid)
    {
        MissedMessages.DeleteMessages(new ConsoleTextWriter(), guid);
    }

    public void MissedMessagesResponse(Guid[] guidArray)
    {
        MissedMessages.DeleteMessages(new ConsoleTextWriter(), guidArray);
    }
}