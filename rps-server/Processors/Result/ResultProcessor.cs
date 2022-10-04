using Microsoft.AspNetCore.SignalR;
using rps_server.DTO.Request.Result;
using rps_server.DTO.Response.Result;
using rps_server.Services.Game;

namespace rps_server.Processors.Result;

public class ResultProcessor : IResultProcessor
{
    private readonly IGameService _gameService;
    
    public ResultProcessor(IGameService gameService)
    {
        _gameService = gameService;
    }
    
    public IResultResponse Process(HubCallerContext context, IClientProxy caller, IResultRequest data)
    {
        return _gameService.GetResultResponse();
    }

    public List<IClientProxy> Clients { get; }
}