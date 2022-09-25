using Microsoft.AspNetCore.SignalR;

namespace rps_server.Repository;

public interface IGame
{
    public bool IsFinished { get; }
    public string GameId { get; }
    public void SetMovement(string uid, MoveType movement);
    public Dictionary<HubCallerContext, GameResult> GetResult();
    public IClient? GetClientById(string uid);
    public IClient? GetClientByConnectionId(string connectionId);
}