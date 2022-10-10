using Newtonsoft.Json;
using rps_server.DTO.Model;

namespace rps_server.DTO.Response.JoinGame;

public interface IJoinGameResponse :  IResponse
{
    [JsonProperty("gameId")]
    string GameId { get; }
    [JsonProperty("players")]
    IList<IPlayerDTO> Players { get; }
}