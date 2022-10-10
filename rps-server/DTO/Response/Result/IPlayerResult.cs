using Newtonsoft.Json;
using rps_server.DTO.Model;

namespace rps_server.DTO.Response.Result;

public interface IPlayerDtoResult : IPlayerDTO
{
    [JsonProperty("move")]
    public int Movement { get; }
    [JsonProperty("result")]
    public int GameResult { get; }
}