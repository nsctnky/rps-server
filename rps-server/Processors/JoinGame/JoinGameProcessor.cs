using Microsoft.AspNetCore.SignalR;
using rps_server.Core.Model;
using rps_server.DTO.Request.JoinGame;
using rps_server.DTO.Response.JoinGame;
using rps_server.DTO.Response.Model;
using rps_server.Services.MatchMake;

namespace rps_server.Processors.JoinGame;

public class JoinGameProcessor : IJoinGameProcessor
{
    private readonly IMatchMakeService _matchMakeService;
    
    public JoinGameProcessor(IMatchMakeService matchMakeService)
    {
        _matchMakeService = matchMakeService;
    }
    
    public void Process(HubCallerContext context, IClientProxy caller)
    {
    }

    public IJoinGameResponse Process(HubCallerContext context, IClientProxy caller, IJoinGameRequest data)
    {
        IGame game = _matchMakeService.GetMatch(context.ConnectionId, 0);
        var players = new List<IPlayer>();
        
        foreach (var val in game.Players)
        {
            players.Add(val.Value);
        }
        
        return new JoinGameResponse(game.GameId, players);
    }
}