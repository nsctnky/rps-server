using Microsoft.AspNetCore.SignalR;
using rps_server.Core.Model;
using rps_server.DTO.Model;
using rps_server.DTO.Request.JoinGame;
using rps_server.DTO.Response.JoinGame;
using rps_server.Services.Game;
using rps_server.Services.MatchMake;

namespace rps_server.Processors.JoinGame;

public class JoinGameProcessor : IJoinGameProcessor
{
    private readonly IMatchMakeService _matchMakeService;
    private readonly IGameService _gameService;
    
    public bool IsGameReady { get; private set; }
    
    public JoinGameProcessor(IMatchMakeService matchMakeService, IGameService gameService)
    {
        _gameService = gameService;
        _matchMakeService = matchMakeService;
    }
    
    public IJoinGameResponse Process(HubCallerContext context, IClientProxy caller, IJoinGameRequest data)
    {
        IGame game = _matchMakeService.GetMatch(context.ConnectionId, 0);

        if (!game.IsFull)
        {
            IsGameReady = false;
            return new JoinGameResponse(-1, "", null);
        }

        var players = new List<IPlayerDTO>();
        foreach (var val in game.GetPlayers())
            players.Add(new PlayerDto(val.Name, val.UserId));
        
        IsGameReady = true;
        _gameService.AddGame(game);
        return new JoinGameResponse(0, game.GameId, players);
    }
}