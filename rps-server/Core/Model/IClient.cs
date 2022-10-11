using Microsoft.AspNetCore.SignalR;

namespace rps_server.Core.Model;

public interface IClient
{
    public string ConnectionId { get; }
    public string UserId { get; }
    public string Name { get; }
    public IClientProxy Caller { get; }
    public bool IsConnected { get; }
    void Disconnect();
}