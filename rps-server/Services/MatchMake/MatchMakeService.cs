using rps_server.DTO.Response.MatchMake;
using rps_server.DTO.Response.Model;

namespace rps_server.Services.MatchMake;

public class MatchMakeService : IMatchMakeService
{
    public IMatchMakeResponse GetMatchMakeResponse(int gameType, string connectionId)
    {
        var players = new List<IPlayer> { new Player("enes", "asd"), new Player("bot1", "bot1") };
        return new MatchMakeResponse(0, "zxc", players);
    }
}