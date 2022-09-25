using Newtonsoft.Json;

namespace rps_server.Response.Move;

public interface IMoveResponse : IResponse
{
    [JsonProperty("uid")]
    public string UserId { get; }
    [JsonProperty("move")]
    public int Movement { get; }
}