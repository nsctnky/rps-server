using Microsoft.AspNetCore.SignalR;
using rps_server.Core.Model;
using rps_server.Core.ServiceLocator;
using rps_server.Core.Utils.Constants;
using rps_server.DTO.Response.Result;

namespace rps_server.Services.Game;

public interface IGameService : IService
{
    bool IsGameFinished();
    ResultResponse GetResultResponse();
    public bool IsFinished { get; }
    public string GameId { get; }
    public void SetMovement(string uid, MoveType movement);
    public Dictionary<IClientProxy, GameResult> GetResult();
    public IClient? GetClientById(string uid);
    public IClient? GetClientByConnectionId(string connectionId);
}