using Microsoft.AspNetCore.SignalR;

namespace SignalRPrototype;

public class MessageHub : Hub
{
    public void AddToGroup(string username)
    {
        Groups.AddToGroupAsync(Context.ConnectionId, username);

        var missedMessages = MissedMessages.GetMessagesByReceiver(username);

        Clients.Group(username).SendAsync("missedMessages", missedMessages);
    }
    
    public void MessageResponse(Guid guid)
    {
        MissedMessages.DeleteMessage(guid, new ConsoleTextWriter());
    }

    public void MissedMessagesResponse(Guid[] guidArray)
    {
        MissedMessages.DeleteMultipleMessages(guidArray, new ConsoleTextWriter());
    }
}