using rps_server.Response.MatchMake;

namespace rps_server.Services.MatchMake;

public interface IMatchMakeService
{
    IMatchMakeResponse GetMatchMakeResponse(int gameType, string connectionId);
}