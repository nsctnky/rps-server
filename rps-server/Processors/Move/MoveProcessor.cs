using Microsoft.AspNetCore.SignalR;
using rps_server.Core.Utils.Constants;
using rps_server.DTO.Request.Move;
using rps_server.DTO.Response.Move;
using rps_server.Services.Game;

namespace rps_server.Processors.Move;

public class MoveProcessor : IMoveProcessor
{
    private readonly IGameService _gameService;
    
    public MoveProcessor(IGameService gameService)
    {
        _gameService = gameService;
    }
    
    public IMoveResponse Process(HubCallerContext context, IClientProxy caller, IMoveRequest data)
    {
        _gameService.SetMove(context.ConnectionId, data.GameId, (MoveType)data.Move);

        GameId = data.GameId;
        IsGameFinished = _gameService.IsGameFinished(data.GameId);
        
        return new MoveResponse(0, data.Move);
    }

    public bool IsGameFinished { get; private set; }
    public string GameId { get; private set; }
}