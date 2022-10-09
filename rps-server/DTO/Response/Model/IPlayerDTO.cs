using Newtonsoft.Json;

namespace rps_server.DTO.Response.Model;

public interface IPlayerDTO
{
    [JsonProperty("name")]
    string Name { get; }
    [JsonProperty("userId")]
    string UserId { get; }
}