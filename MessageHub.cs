using Microsoft.AspNetCore.SignalR;

namespace SignalRPrototype;

//TODO: refactor to strongly typed hub
public class MessageHub : Hub
{
    public async Task MessageAll(Message message)
        => await Clients.All.SendAsync("message", message);

    public Task MessageUser(string groupName, Message message)
    {
        return Clients.Group(groupName).SendAsync("message", message);
    }

    public async Task AddToGroup(string username)
    {
        var groupName = "user_" + username;

        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        var message = new Message($"{Context.ConnectionId} has joined the group {groupName}.", "MessageHub", groupName);

        await Clients.Group(groupName).SendAsync("message", message);
    }
}
