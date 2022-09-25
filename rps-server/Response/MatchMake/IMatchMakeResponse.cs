using Newtonsoft.Json;
using rps_server.Response.Model;

namespace rps_server.Response.MatchMake;

public interface IMatchMakeResponse : IResponse
{
    [JsonProperty("players")]
    List<IPlayer> Players { get; }
    [JsonProperty("gameId")]

    public string GameId { get; }

}