using Newtonsoft.Json;
using rps_server.Response.Model;

namespace rps_server.Response.Result;

public interface IPlayerResult : IPlayer
{
    [JsonProperty("move")]
    public int Movement { get; }
}