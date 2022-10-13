using Microsoft.AspNetCore.SignalR;

namespace rps_server.Core.Model;

public interface IClient
{
    IGame? CurrentGame { get; }
    bool IsInGame { get; }
    string ConnectionId { get; }
    string UserId { get; }
    string Name { get; }
    IClientProxy Caller { get; }
    bool IsConnected { get; }
    void Disconnect();
    void SetCurrentGame(IGame? game);
}