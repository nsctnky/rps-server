using Newtonsoft.Json;
using rps_server.DTO.Response.Model;

namespace rps_server.DTO.Response.MatchMake;

public interface IMatchMakeResponse : IResponse
{
    [JsonProperty("players")]
    List<IPlayer> Players { get; }
    [JsonProperty("gameId")]

    public string GameId { get; }
}