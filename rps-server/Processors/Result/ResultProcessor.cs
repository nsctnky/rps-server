using Microsoft.AspNetCore.SignalR;
using rps_server.Core.Model;
using rps_server.DTO.Request.Result;
using rps_server.DTO.Response.Result;
using rps_server.Services.Game;

namespace rps_server.Processors.Result;

public class ResultProcessor : IResultProcessor
{
    private readonly IGameService _gameService;
    public List<IClient> Clients { get; }

    public ResultProcessor(IGameService gameService)
    {
        _gameService = gameService;
        Clients = new List<IClient>();
    }
    
    public IResultResponse Process(HubCallerContext context, IClientProxy caller, IResultRequest data)
    {
        var dict = _gameService.GetResultResponse(data.GameId);
        var list = new List<IPlayerDtoResult>();
        foreach (var pair in dict)
            list.Add(new PlayerDtoResult(pair.Key.Name, pair.Key.UserId, (int)pair.Value.Key, (int)pair.Value.Value));

        foreach (var player in dict)
        {
            Clients.Add(player.Key);
        }
        
        _gameService.ClearGame(data.GameId);
        return new ResultResponse(0, list);
    }

}