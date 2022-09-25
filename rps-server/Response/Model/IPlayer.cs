using Newtonsoft.Json;

namespace rps_server.Response.Model;

public interface IPlayer
{
    [JsonProperty("name")]
    string Name { get; }
    [JsonProperty("userId")]
    string UserId { get; }
}