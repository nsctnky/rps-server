using Newtonsoft.Json;

namespace rps_server.Response.Auth;

public interface IAuthResponse : IResponse
{
    [JsonProperty("name")]
    public string Name { get; }
    [JsonProperty("userId")]
    public string UserId { get; }
}