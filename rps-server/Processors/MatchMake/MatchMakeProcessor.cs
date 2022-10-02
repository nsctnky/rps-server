using Microsoft.AspNetCore.SignalR;
using rps_server.Core.Model;
using rps_server.DTO.Request.MatchMake;
using rps_server.DTO.Response.MatchMake;
using rps_server.DTO.Response.Model;
using rps_server.Services.MatchMake;

namespace rps_server.Processors.MatchMake;

public class MatchMakeProcessor : IMatchMakeProcessor
{
    private readonly IMatchMakeService _matchMakeService;
    
    public MatchMakeProcessor(IMatchMakeService makeService)
    {
        _matchMakeService = makeService;
    }
    
    public IMatchMakeResponse Process(HubCallerContext context, IClientProxy caller, IMatchMakeRequest data)
    {
        IGame game = _matchMakeService.GetMatch(context.ConnectionId, 0);
        var players = new List<IPlayer>();
        
        foreach (var val in game.Players)
        {
            players.Add(val.Value);
        }
        
        return new MatchMakeResponse(0, game.GameId, players);
    }
}