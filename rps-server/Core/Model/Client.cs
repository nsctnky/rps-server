using Microsoft.AspNetCore.SignalR;

namespace rps_server.Core.Model;

public class Client : IClient
{
    public string ConnectionId { get; }
    public string UserId { get; }
    public string Name { get; }
    public IClientProxy Caller { get; }

    public Client(string connectionId, string userId, string name, IClientProxy caller)
    {
        ConnectionId = connectionId;
        UserId = userId;
        Caller = caller;
        Name = name;
    }
}