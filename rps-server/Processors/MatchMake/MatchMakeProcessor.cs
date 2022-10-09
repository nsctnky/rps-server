using Microsoft.AspNetCore.SignalR;
using rps_server.DTO.Request.MatchMake;
using rps_server.DTO.Response.MatchMake;
using rps_server.Services.MatchMake;

namespace rps_server.Processors.MatchMake;

public class MatchMakeProcessor : IMatchMakeProcessor
{
    private readonly IMatchMakeService _matchMakeService;

    public MatchMakeProcessor(IMatchMakeService matchMakeService)
    {
        _matchMakeService = matchMakeService;
    }
    
    public IMatchMakeResponse Process(HubCallerContext context, IClientProxy caller, IMatchMakeRequest data)
    {
        _matchMakeService.AddClientToWaiting(context.ConnectionId);
        return new MatchMakeResponse(0);
    }
}