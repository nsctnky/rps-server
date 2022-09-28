using Newtonsoft.Json;
using rps_server.DTO.Response.Model;

namespace rps_server.DTO.Response.Result;

public interface IPlayerResult : IPlayer
{
    [JsonProperty("move")]
    public int Movement { get; }
}