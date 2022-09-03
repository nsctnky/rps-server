using Newtonsoft.Json;
using rps_server.Response.Model;

namespace rps_server.Response.MatchMake;

public class MatchMakeResponse : IMatchMakeResponse
{
    [JsonProperty("command")]
    public string Command { get; private set; }
    [JsonProperty("error")]
    public int Error { get; private set; }
    [JsonProperty("players")]
    public List<IPlayer> Players { get; private set; }

    public MatchMakeResponse( int error, IEnumerable<IPlayer> players)
    {
        Command = "matchMake";
        Error = error;

        Players = new List<IPlayer>();
        Players.AddRange(players);
    }

    public string ToJson()
    {
        return JsonConvert.SerializeObject(this);
    }
}