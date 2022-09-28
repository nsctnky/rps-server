using Newtonsoft.Json;
using rps_server.DTO.Response.Model;

namespace rps_server.DTO.Response.MatchMake;

public class MatchMakeResponse : IMatchMakeResponse
{
    public string Command { get; }
    public int Error { get; }
    public string GameId { get; }
    public List<IPlayer> Players { get; }

    public MatchMakeResponse(int error, string gameId, IEnumerable<IPlayer> players)
    {
        Command = "matchMake";
        Error = error;
        GameId = gameId;
        Players = new List<IPlayer>();
        Players.AddRange(players);
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}