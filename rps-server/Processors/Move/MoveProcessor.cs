using Microsoft.AspNetCore.SignalR;
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
        return new MoveResponse(0, 0);
    }

    public bool IsGameFinished { get; private set; }
}