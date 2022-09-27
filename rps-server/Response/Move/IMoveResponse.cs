using Newtonsoft.Json;

namespace rps_server.Response.Move;

public interface IMoveResponse : IResponse
{
    [JsonProperty("move")]
    public int Movement { get; }
}