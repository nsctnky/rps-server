using Microsoft.AspNetCore.SignalR;

namespace rps_server.Core.Model;

public class Client : IClient
{
    public IGame? CurrentGame { get; private set; }
    public bool IsInGame { get; private set; }
    public string ConnectionId { get; }
    public string UserId { get; }
    public string Name { get; }
    public IClientProxy Caller { get; }
    public bool IsConnected { get; private set; }
    
    public void Disconnect()
    {
        CurrentGame?.DisconnectPlayer(ConnectionId);    
        IsInGame = false;
        IsConnected = false;
    }

    public void SetCurrentGame(IGame? game)
    {
        if (game == null)
        {
            IsInGame = false;
            CurrentGame = null;
            return;
        }
        
        CurrentGame = game;
        IsInGame = true;
    }

    public Client(string connectionId, string userId, string name, IClientProxy caller)
    {
        ConnectionId = connectionId;
        UserId = userId;
        Caller = caller;
        Name = name;
        IsConnected = true;
    }
}