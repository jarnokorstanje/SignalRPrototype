using Microsoft.AspNetCore.SignalR;

namespace SignalRPrototype;

public class MessageHub : Hub
{
    public void AddToGroup(string username)
    {
        Groups.AddToGroupAsync(Context.ConnectionId, username);

        var missedMessages = MessageStorage.GetMessagesByReceiver(username); //TODO: nadenken over of deze ook een ontvangst bevestiging moeten sturen.

        Clients.Group(username).SendAsync("missedMessages", missedMessages);
    }
    
    public void MessageResponse(Guid guid)
    {
        MessageStorage.DeleteMessage(guid, new ConsoleTextWriter());
    }

    public void MissedMessagesResponse(Guid[] guidArray)
    {
        MessageStorage.DeleteMultipleMessages(guidArray, new ConsoleTextWriter());
    }
}