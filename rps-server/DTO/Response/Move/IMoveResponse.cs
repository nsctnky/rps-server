using Newtonsoft.Json;

namespace rps_server.DTO.Response.Move;

public interface IMoveResponse : IResponse
{
    [JsonProperty("move")]
    public int Movement { get; }
}