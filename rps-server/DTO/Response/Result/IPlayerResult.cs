using Newtonsoft.Json;
using rps_server.DTO.Response.Model;

namespace rps_server.DTO.Response.Result;

public interface IPlayerDtoResult : IPlayerDTO
{
    [JsonProperty("move")]
    public int Movement { get; }
}