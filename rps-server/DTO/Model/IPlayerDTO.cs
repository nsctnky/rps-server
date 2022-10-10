using Newtonsoft.Json;

namespace rps_server.DTO.Model;

public interface IPlayerDTO
{
    [JsonProperty("name")]
    string Name { get; }
    [JsonProperty("userId")]
    string UserId { get; }
}