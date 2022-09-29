using Microsoft.AspNetCore.SignalR;
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
        var players = new List<IPlayer> { new Player("enes", "asd"), new Player("bot1", "bot1") };
        return new MatchMakeResponse(0, "test", players);
    }
}